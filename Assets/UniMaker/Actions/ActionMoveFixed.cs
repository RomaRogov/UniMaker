using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
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
			EditorGUILayout.LabelField("Direction: ");

			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			selected = GUILayout.SelectionGrid(selected, new List<Directions>((Directions[])Enum.GetValues(typeof(Directions))).ConvertAll(x => IconCacher.GetIcon<Directions>(x)).ToArray(), 3);
			if (selected != 4)
			{
				Direction = directions[selected];
				TextInList = "Move " + Direction.ToString() + "\u00B0 with speed " + Speed.ToString();
			}
			else
			{
				JustStop = true;
				TextInList = "Stop";
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			SerializedObject thisSerialized = new SerializedObject(this);
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(thisSerialized.FindProperty("Speed"));
			thisSerialized.ApplyModifiedProperties();

			EditorGUILayout.EndVertical();
			#endif
		}

	}
}