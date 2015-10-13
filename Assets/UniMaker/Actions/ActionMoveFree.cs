using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker
{
	[Serializable]
	public class ActionMoveFree : ActionBase
	{
		protected float uiDirection = 0;
		protected float uiSpeed = 0;

		public float Direction = 0;
		public float Speed = 0;

		public ActionMoveFree():base(ActionTypes.MoveFree) { TextInList = "Move Free"; }

		internal override bool Execute (GMakerObject obj)
		{
			//Rotate and set speed
			return base.Execute (obj);
		}

		public override void DrawGUIProperty ()
		{
			#if UNITY_EDITOR
			EditorGUILayout.BeginVertical();
			EditorGUILayout.Space();
			uiDirection = EditorGUILayout.FloatField("Direction: ", uiDirection);
			EditorGUILayout.Space();
			uiSpeed = EditorGUILayout.FloatField("Speed: ", uiSpeed);
			EditorGUILayout.EndVertical();
			#endif
		}

		public override void ApplyGUI ()
		{
			Direction = uiDirection;
			Speed = uiSpeed;
			TextInList = "Move " + Direction.ToString() + "\u00B0 with speed " + Speed.ToString();
		}

		public override void ResetGUI ()
		{
			CanBeRelative = false;
			uiDirection = Direction;
			uiSpeed = Speed;
		}

		internal override JSONObject GetJSON ()
		{
			JSONObject baseJSON = base.GetJSON ();
			baseJSON.AddField("Direction", Direction);
			baseJSON.AddField("Speed", Speed);
			return baseJSON;
		}
		
		internal override void ParseJSON (JSONObject input)
		{
			base.ParseJSON (input);
			Direction = input["Direction"].f;
			Speed = input["Speed"].f;
		}
	}
}