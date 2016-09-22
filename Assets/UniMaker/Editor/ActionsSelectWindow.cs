using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class ActionsSelectWindow : EditorWindow
	{
		private const int itemSize = 24;

		private Vector2 scrollValue = Vector2.zero;
        
		private ActionTabTypes selectedTab = ActionTabTypes.TabTransform;

		private ActionTypes actionToDrag = ActionTypes.None;

        [MenuItem("UniMaker/Actions Selector")]
		static void Init()
		{
			ActionsSelectWindow wnd = EditorWindow.GetWindow<ActionsSelectWindow>("Actions");
			wnd.Show();
		}
		
		void OnGUI()
		{
			if (Event.current.type == EventType.MouseDrag && (actionToDrag != ActionTypes.None))
			{
				DragAndDrop.PrepareStartDrag();
				DragAndDrop.SetGenericData("ActionTypes", actionToDrag);
				DragAndDrop.paths = null;
				DragAndDrop.objectReferences = new Object[0];

				DragAndDrop.StartDrag(actionToDrag.ToString());

				Event.current.Use();
			}
			if (Event.current.type == EventType.DragExited)
			{
 				actionToDrag = ActionTypes.None;
			}

			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			scrollValue = EditorGUILayout.BeginScrollView(scrollValue, GUI.skin.box);
            
			switch (selectedTab)
			{
				case ActionTabTypes.TabTransform: DrawTransformTab(); 			break;
			}
            
			EditorGUILayout.EndScrollView();

			EditorGUILayout.EndHorizontal();
		}

		/* TRANSFORM TAB  */
        
		private List<ActionTypes> move_positionTypes = new List<ActionTypes>() {
			ActionTypes.Translate
		};
        
        private void DrawTransformTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Position: ", move_positionTypes);
			GUILayout.EndVertical();
		}

		/* END OF TAB LIST */

		private void DrawTypeGrid(string title, List<ActionTypes> listToDraw)
		{
			GUILayout.Label(title);
            
			foreach (ActionTypes type in listToDraw)
			{
				if (GUILayout.RepeatButton(new GUIContent(type.ToString(), IconCacher.GetIcon<ActionTypes>(type), type.ToString())) && Event.current.type == EventType.Repaint)
				{
					actionToDrag = type;
				}
			}
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