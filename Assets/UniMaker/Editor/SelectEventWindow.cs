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
		private GMakerObject target;
		private List<string> GMObjectsToCollide;
        
		internal static void Open(GMakerObject targetGMObj)
		{
			SelectEventWindow wnd = EditorWindow.GetWindow<SelectEventWindow>(true, "Select event");
			wnd.target = targetGMObj;
			wnd.GMObjectsToCollide = new List<string>() { "Any" };
			wnd.GMObjectsToCollide.AddRange(Array.ConvertAll<GMakerObject, string>(Resources.FindObjectsOfTypeAll<GMakerObject>(), x => x.FabPath));
			wnd.ShowUtility();
		}
		
		void OnGUI()
		{
			if (target == null)
			{
				Close();
				return;
			}

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