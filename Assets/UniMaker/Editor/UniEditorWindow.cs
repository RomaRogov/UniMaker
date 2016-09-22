using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UniMaker.Actions;

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

			EditorGUILayout.BeginVertical(GUILayout.Width(150));
			EditorGUILayout.LabelField("Events:");
			scrollValue = EditorGUILayout.BeginScrollView(scrollValue, GUI.skin.box);
			if (data.EventCount == 0)
			{
				DrawLabelInCenter("No events here!\nAdd any?");
			}
			for (int i = 0; i < data.EventCount; i++)
			{
				DrawEvent(IconCacher.GetIcon<EventTypes>(data.Events[i].Type), data.Events[i].Type.ToString(), i);
			}
			EditorGUILayout.EndScrollView();
			if (GUILayout.Button("Add event"))
			{
				data.Events.Add(new UniEvent("{\"type\":\"" + "Update" + "\"}", ""));
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
                            data.Events[selectedEventIndex].Actions.Add(GetActionInstanceByType((ActionTypes)dropData));
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
			GUI.backgroundColor = active ? Color.blue : prevColor;

			Rect area = EditorGUILayout.BeginHorizontal(GUILayout.MaxHeight(itemSize));
			if (EditorGUI.Toggle(area, active, GUI.skin.box) && !active)
			{
				SelectEvent(index);
			}
			EditorGUILayout.Space();
			GUILayout.Label(icon, GUILayout.Width(itemSize), GUILayout.Height(itemSize));
			EditorGUILayout.BeginVertical(GUILayout.MaxHeight(itemSize));
			GUILayout.FlexibleSpace();
			EditorGUILayout.LabelField(eventName, GUILayout.MinWidth(130));
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndVertical();
			GUILayout.FlexibleSpace();
	        EditorGUILayout.EndHorizontal();

			GUI.backgroundColor = prevColor;
		}

		private void SelectEvent(int selectIndex)
		{
			selectedEventIndex = selectIndex;

			list = new ReorderableList(data.Events[selectedEventIndex].Actions, typeof(ActionBase));
			list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				ActionBase element = data.Events[selectedEventIndex].Actions[index];
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

		public static ActionBase GetActionInstanceByType(ActionTypes type)
		{
			return (ActionBase)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Actions.Action" + type.ToString()).Unwrap();
		}
	}
}