using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class SelectEventWindow : EditorWindow
	{
        
		internal static void Open()
		{
			SelectEventWindow wnd = EditorWindow.GetWindow<SelectEventWindow>(true, "Select event");
			wnd.ShowUtility();
		}
		
		void OnGUI()
		{

			DrawLabelInCenter("Still in development");
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