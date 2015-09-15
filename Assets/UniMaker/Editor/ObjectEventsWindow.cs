using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

namespace UniMaker
{
	public class ObjectEventsWindow : EditorWindow
	{
		private const int itemSize = 20;
		private const int actionItemSize = 24;

		private Vector2 scrollValue = Vector2.zero;
		private GMakerObject selectedObject;

		private ReorderableList list;

		[MenuItem("UniMaker/Events Inspector")]
		static void Init()
		{
			ObjectEventsWindow wnd = EditorWindow.GetWindow<ObjectEventsWindow>("Events");
			wnd.OnSelectionChange();
			wnd.Show();
		}

		void OnSelectionChange()
		{
			if (Selection.activeObject is GameObject)
			{
				selectedObject = ((GameObject)Selection.activeObject).GetComponent<GMakerObject>();
				if ((selectedObject != null) && (selectedObject.Events.Count > 0))
				{
					SelectEvent(selectedObject.SelectedEventIndex);
				}
			}
			else
			{
				selectedObject = null;
			}
			Repaint();
		}
		
		void OnGUI()
		{
			if (selectedObject == null)
			{
				DrawLabelInCenter("Select any GMakerObject");
				return;
			}

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.BeginVertical(GUILayout.Width(150));
			EditorGUILayout.LabelField("Events:");
			scrollValue = EditorGUILayout.BeginScrollView(scrollValue, GUI.skin.box);
			if (selectedObject.Events.Count == 0)
			{
				DrawLabelInCenter("No events here!\nAdd any?");
			}
			for (int i = 0; i < selectedObject.Events.Count; i++)
			{
				DrawEvent(IconCacher.GetEventIcon(selectedObject.Events[i].Type), selectedObject.Events[i].Type.ToString(), i);
			}
			EditorGUILayout.EndScrollView();
			if (GUILayout.Button("Add event"))
			{
				selectedObject.Events.Add(new GMakerObject.EventInstance(EventTypes.EventMouse));
				SelectEvent(selectedObject.Events.Count - 1);
			}
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Delete"))
			{
				selectedObject.Events.RemoveAt(selectedObject.SelectedEventIndex);
				if (selectedObject.SelectedEventIndex > 0) { selectedObject.SelectedEventIndex--; }
				if (selectedObject.Events.Count > 0)
				{
					SelectEvent(selectedObject.SelectedEventIndex);
				}
			}
			GUILayout.Button("Change");
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical();
			EditorGUILayout.LabelField("Actions:");
			if (selectedObject.Events.Count == 0)
			{
				DrawLabelInCenter("No event selected");
			}
			else
			{
				list.DoLayoutList();
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();
		}

		private void DrawEvent(Texture icon, string eventName, int index)
		{
			bool active = index == selectedObject.SelectedEventIndex;

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
			selectedObject.SelectedEventIndex = selectIndex;

			list = new ReorderableList(selectedObject.SelectedEvent.Actions, typeof(GMakerObject.ActionInstance));
			list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				GMakerObject.ActionInstance element = selectedObject.SelectedEvent.Actions[index];
				rect.y -= 1;
				EditorGUI.LabelField(new Rect(rect.x, rect.y, actionItemSize, actionItemSize), new GUIContent(IconCacher.GetActionIcon(element.Type)));
				rect.y += 3;
				EditorGUI.LabelField(new Rect(rect.x + actionItemSize, rect.y, rect.width - actionItemSize, actionItemSize), element.Type.ToString());
			};
			list.onAddCallback = (l) =>
			{
				selectedObject.SelectedEvent.Actions.Add(new GMakerObject.ActionInstance(ActionTypes.ExecuteCode));
			};
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