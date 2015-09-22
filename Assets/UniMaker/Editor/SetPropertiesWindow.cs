using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class SetPropertiesWindow : EditorWindow
	{
		private ActionBase action;
        
		internal static void Open(ActionBase actionToOpen)
		{
			SetPropertiesWindow wnd = EditorWindow.GetWindow<SetPropertiesWindow>("Set Properties");
			wnd.action = actionToOpen;
			wnd.Show();
		}
		
		void OnGUI()
		{
			if (action != null)
			{
				action.DrawGUIProperty();
			}
			else
			{
				Close();
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