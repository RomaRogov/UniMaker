using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;
using System.Collections.Generic;
using UniMaker.Actions;

namespace UniMaker
{
	public class SetPropertiesWindow : EditorWindow
	{
		private UniAction action;
		private List<string> GMObjectsToApply;
        
		internal static void Open(UniAction actionToOpen)
		{
			if (actionToOpen != null)
			{
				actionToOpen.ResetGUI();
			}
            
			SetPropertiesWindow wnd = EditorWindow.GetWindow<SetPropertiesWindow>(true, actionToOpen.Type.ToString());
			wnd.action = actionToOpen;
			wnd.ShowUtility();
		}
		
		void OnGUI()
		{
			if (action == null)
			{
				Close();
				return;
			}

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label(IconCacher.GetIcon<ActionTypes>(action.Type));

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField(action.TextInList);
			EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();

			action.DrawGUIProperty();

			GUILayout.FlexibleSpace();

            /*
			if (action.CanBeRelative)
			{
				EditorGUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				action.Relative = EditorGUILayout.ToggleLeft("Relative", action.Relative, GUILayout.Width(70));
				GUILayout.FlexibleSpace();
				EditorGUILayout.EndHorizontal();

				EditorGUILayout.Space();
			}
            */
			EditorGUILayout.BeginHorizontal();
			GUILayout.Space(5);
			Color backup = GUI.backgroundColor;
			GUI.backgroundColor = Color.green;
			if (GUILayout.Button("OK", GUILayout.Width(100)))
			{
				Close();
				action.ApplyGUI();
				UniEditorWindow objWnd = EditorWindow.GetWindow<UniEditorWindow>();
				objWnd.SetObjectDirty();
				objWnd.Repaint();
			}
			GUILayout.FlexibleSpace();
			GUI.backgroundColor = Color.red;
			if (GUILayout.Button("Cancel", GUILayout.Width(100)))
			{
				Close();
			}
			GUILayout.Space(5);
			GUI.backgroundColor = backup;
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
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