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
			SerializedObject thisSerialized = new SerializedObject(this);
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(thisSerialized.FindProperty("Direction"));
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(thisSerialized.FindProperty("Speed"));
			EditorGUILayout.EndVertical();
			thisSerialized.ApplyModifiedProperties();
			TextInList = "Move " + Direction.ToString() + "\u00B0 with speed " + Speed.ToString();
			#endif
		}

	}
}