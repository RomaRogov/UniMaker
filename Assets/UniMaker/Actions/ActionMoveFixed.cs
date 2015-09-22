using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker
{
	[Serializable]
	public class ActionMoveFixed : ActionMoveFree
	{
		public bool JustStop = false;

		private float[] directions = new float[9] { 135, 90, 45, 180, 0, 0, 225, 270, 315 };
		private string[] captions = new string[9] { "\\", "^", "/", "<", "o", ">", "/", "V", "\\" }; //TODO: Temporary solution, change to icons!
		private int selected = 5;

		public ActionMoveFixed():base() { Type = ActionTypes.MoveFixed; TextInList = "Move Free"; }

		internal override bool Execute (GMakerObject obj)
		{
			if (JustStop)
			{
				//Stop
				return true;
			}
			else
			{
				return base.Execute (obj);
			}
		}

		public override void DrawGUIProperty ()
		{
			#if UNITY_EDITOR
			EditorGUILayout.BeginVertical();
			SerializedObject thisSerialized = new SerializedObject(this);

			EditorGUILayout.LabelField("Direction: ");
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			selected = GUILayout.SelectionGrid(selected, captions, 3);
			if (selected != 4)
			{
				Direction = directions[selected];
				TextInList = "Move to direction " + Direction.ToString() + " degrees";
			}
			else
			{
				JustStop = true;
				TextInList = "Stop";
			}
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();
			#endif
		}

	}
}