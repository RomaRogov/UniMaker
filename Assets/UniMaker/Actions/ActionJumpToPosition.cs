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
		public Vector2 uiPosition;

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

			uiPosition = EditorGUILayout.Vector2Field("Position: ", uiPosition);
			EditorGUILayout.EndVertical();
			#endif
		}

		public override void ApplyGUI ()
		{
			Position = uiPosition;
			TextInList = "Jump to position (" + Position.x.ToString() + "; " + Position.y.ToString() + ")";
		}
		
		public override void ResetGUI ()
		{
			CanBeRelative = true;
			uiPosition = Position;
		}

		internal override JSONObject GetJSON ()
		{
			JSONObject baseJSON = base.GetJSON ();
			baseJSON.AddField("Position_x", Position.x);
			baseJSON.AddField("Position_y", Position.y);
			return baseJSON;
		}

		internal override void ParseJSON (JSONObject input)
		{
			base.ParseJSON (input);
			Position = new Vector2(input["Position_x"].f, input["Position_y"].f);
		}
	}
}