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

		private float[] directions = new float[9] { 135, 90, 45, 180, -1, 0, 225, 270, 315 };
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
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			EditorGUILayout.Space();
			uiSpeed = EditorGUILayout.FloatField("Speed: ", uiSpeed);

			EditorGUILayout.EndVertical();
			#endif
		}

		public override void ApplyGUI ()
		{
			TextInList = "Move " + Direction.ToString() + "\u00B0 with speed " + Speed.ToString();
			if (selected != 4)
			{
				JustStop = false;
				Direction = directions[selected];
				TextInList = "Move " + Direction.ToString() + "\u00B0 with speed " + Speed.ToString();
			}
			else
			{
				JustStop = true;
				TextInList = "Stop";
			}
			Speed = uiSpeed;
		}
		
		public override void ResetGUI ()
		{
			uiDirection = Direction;
			if (JustStop)
			{
				selected = 4;
			}
			else
			{
				selected = Array.IndexOf<float>(directions, Direction);
				if (selected < 0)
				{
					selected = 0;
				}
			}
			uiSpeed = Speed;
		}

		internal override JSONObject GetJSON ()
		{
			JSONObject baseJSON = base.GetJSON ();
			baseJSON.AddField("JustStop", JustStop);
			return baseJSON;
		}
		
		internal override void ParseJSON (JSONObject input)
		{
			base.ParseJSON (input);
			JustStop = input["JustStop"].b;
		}
	}
}