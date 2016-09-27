using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UniMaker.Actions;
using UniMaker.Events;

namespace UniMaker
{
    public class UniEditorWindow : EditorWindow
	{
		private const int itemSize = 20;
		private const int actionItemSize = 24;
		private const float doubleClickTime = 0.3f;

		private Vector2 scrollValue = Vector2.zero;
        private UniEditorAbstract data;
        private int selectedEventIndex = 0;
		private int? lastSelectedIndex = null;
		private double lastClickTime = 0;

		private ReorderableList list;

        [MenuItem("UniMaker/Events Inspector")]
		static void Init()
		{
			UniEditorWindow wnd = EditorWindow.GetWindow<UniEditorWindow>("Events");
			wnd.OnSelectionChange();
			wnd.Show();
		}

		void OnSelectionChange()
		{
            selectedEventIndex = 0;

            if ((data != null) && !data.ParseFailed)
            {
                data.CombineScript(new StreamWriter(data.FileName, false));
                AssetDatabase.ImportAsset(data.FileName);
            }
            data = null;

            if (Selection.activeObject is MonoScript)
            {
                UniEditorAbstract parsedScript = new UniEditorAbstract(((MonoScript)Selection.activeObject).text, AssetDatabase.GetAssetPath(Selection.activeObject));
                if (!parsedScript.ParseFailed) { data = parsedScript; }
            }
            
			Repaint();
		}
		
		void OnGUI()
		{
			if (data == null)
			{
				DrawLabelInCenter("Select any UniBehaviour script");
				return;
			}

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.BeginVertical(GUILayout.MaxWidth(210));
			EditorGUILayout.LabelField("Events:");
			scrollValue = EditorGUILayout.BeginScrollView(scrollValue, GUI.skin.box);
			if (data.EventCount == 0)
			{
				DrawLabelInCenter("No events here!\nAdd any?");
			}
			for (int i = 0; i < data.EventCount; i++)
			{
				DrawEvent(IconCacher.GetIcon<EventTypes>(data.Events[i].Type), data.Events[i].TextInList, i);
			}
			EditorGUILayout.EndScrollView();

            EventTypes eventToAdd = EventTypes.None;
            List<string> options = new List<string>();
            options.Add("None");
            options.Add("Start");
            options.Add("Update");
            List<string> keyNames = new List<string>() { "Left", "Right", "Up", "Down", "Ctrl", "Alt", "Shift", "Space", "Enter", "Backspace", "Escape", "Home", "End", "PageUp", "PageDown", "Delete", "Insert", "Any Key", "No Key" };
            keyNames.ForEach(k => options.Add("Key Press/<" + k + ">"));
            keyNames.ForEach(k => options.Add("Key Down/<" + k + ">"));
            keyNames.ForEach(k => options.Add("Key Up/<" + k + ">"));
            int selectedEvent = EditorGUILayout.Popup("Add event:", 0, options.ToArray());
            eventToAdd = (EventTypes)(selectedEvent);
            if (eventToAdd != EventTypes.None)
			{
                UniEvent newEvent = UniEvent.GetEventInstanceByType(eventToAdd);
                data.Events.Add(newEvent);
				SelectEvent(data.EventCount - 1);
				SetObjectDirty();
			}
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Delete"))
			{
				data.Events.RemoveAt(selectedEventIndex);
				if (selectedEventIndex > 0) { selectedEventIndex--; }
				if (data.EventCount > 0)
				{
					SelectEvent(selectedEventIndex);
				}
				SetObjectDirty();
			}
			GUILayout.Button("Change");
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();

			Rect dropArea = EditorGUILayout.BeginVertical();
			EditorGUILayout.LabelField("Actions:");

			if (dropArea.Contains(Event.current.mousePosition))
			{
				object dropData = null;
				switch(Event.current.type)
				{
					case EventType.DragUpdated:
                        dropData = DragAndDrop.GetGenericData("ActionTypes");
	                    if (dropData is ActionTypes)
						{
							DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
						}
						break;

					case EventType.DragPerform:
                        dropData = DragAndDrop.GetGenericData("ActionTypes");
						if (dropData is ActionTypes && (data.EventCount > 0))
						{
							DragAndDrop.AcceptDrag();
                            data.Events[selectedEventIndex].Actions.Add(UniAction.GetActionInstanceByType((ActionTypes)dropData));
							DragAndDrop.SetGenericData("ActionTypes", null);
							SetObjectDirty();
						}
						break;
				}
			}
			
			if (data.EventCount == 0)
			{
				DrawLabelInCenter("No event selected");
			}
			else
			{
				if (list == null)
				{
					SelectEvent(selectedEventIndex);
				}
				list.DoLayoutList();
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();
		}

		private void DrawEvent(Texture icon, string eventName, int index)
		{
			bool active = index == selectedEventIndex;

			Color prevColor = GUI.backgroundColor;
			GUI.backgroundColor = active ? new Color(.5f, .5f, 1, 1) : prevColor;

			Rect area = EditorGUILayout.BeginHorizontal();
            if (EditorGUI.Toggle(area, active, GUI.skin.box) && !active)
            {
                SelectEvent(index);
            }

            //EditorGUILayout.LabelField(new GUIContent(icon), GUILayout.MaxWidth(itemSize));
            EditorGUILayout.BeginVertical(GUILayout.Height(itemSize));
            GUILayout.FlexibleSpace();
            GUI.skin.label.wordWrap = true;
            EditorGUILayout.LabelField(new GUIContent(eventName, icon), GUI.skin.label, GUILayout.Height(itemSize));
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndVertical();
            GUILayout.FlexibleSpace();

            EditorGUILayout.EndHorizontal();

			GUI.backgroundColor = prevColor;
		}

		private void SelectEvent(int selectIndex)
		{
			selectedEventIndex = selectIndex;

			list = new ReorderableList(data.Events[selectedEventIndex].Actions, typeof(UniAction));
			list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				UniAction element = data.Events[selectedEventIndex].Actions[index];
				rect.y -= 1;
				EditorGUI.LabelField(new Rect(rect.x, rect.y, actionItemSize, actionItemSize), new GUIContent(IconCacher.GetIcon<ActionTypes>(element.Type)));
				rect.y += 3;
				EditorGUI.LabelField(new Rect(rect.x + actionItemSize, rect.y, rect.width - actionItemSize, actionItemSize), element.TextInList);
			};
			list.onAddCallback = (l) =>
			{
				ActionsSelectWindow wnd = EditorWindow.GetWindow<ActionsSelectWindow>("Actions");
				wnd.Show();
			};
			list.drawHeaderCallback = (Rect rect) =>
			{
				GUI.Label(rect, "Drag actions here");
			};
			list.onSelectCallback = (x) =>
			{
				if (lastSelectedIndex == x.index)
				{
					if ((EditorApplication.timeSinceStartup - lastClickTime) < doubleClickTime)
					{
						SetPropertiesWindow.Open(data.Events[selectedEventIndex].Actions[x.index]);
					}
				}

				lastSelectedIndex = x.index;
				lastClickTime = EditorApplication.timeSinceStartup;
			};
			list.onChangedCallback = (l) => { SetObjectDirty(); };
		}

		internal void SetObjectDirty()
		{
            /*
			if (selectedObject != null)
			{
				selectedObject.SaveDataToJSON();
				EditorUtility.SetDirty(selectedObject);
			}
            */
		}

		private static void DrawLabelInCenter(string text)
		{
			EditorGUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.LabelField(text, GUI.skin.box);
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndVertical();
		}
	}
}