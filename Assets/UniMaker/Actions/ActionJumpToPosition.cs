using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker
{
	[Serializable]
	public class ActionJumpToPosition : ActionBase
	{
		public Vector2 Position;

		public ActionJumpToPosition():base(ActionTypes.JumpToPosition) { TextInList = "Jump to position"; }

		internal override bool Execute (GMakerObject obj)
		{
			obj.transform.localPosition = new Vector3(Position.x, Position.y, obj.transform.localPosition.z);
			return base.Execute (obj);
		}

		public override void DrawGUIProperty ()
		{
			#if UNITY_EDITOR
			EditorGUILayout.BeginVertical();
			SerializedObject thisSerialized = new SerializedObject(this);

			EditorGUILayout.LabelField("Position: ");
			EditorGUILayout.PropertyField(thisSerialized.FindProperty("Position"));
			EditorGUILayout.EndVertical();
			thisSerialized.ApplyModifiedProperties();
			TextInList = "Jump to position (" + Position.x.ToString() + "; " + Position.y.ToString() + ")";
			#endif
		}

	}
}