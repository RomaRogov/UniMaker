using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker.Actions
{
	public class ActionTransformTranslate : ActionBase
	{
		public Vector3 uiTranslation;

		public Vector3 Translation;

		public ActionTransformTranslate():base(ActionTypes.TransformTranslate) { TextInList = "Translate to"; }

        public override void SetOptionsAndContent(string options, string content)
        {
            //DO SOMETHING
            Debug.Log("Action options:" + options + "\nContent: " + content);
            content = "transfrom.Translate(new Vector3(" + Translation.x.ToString() + "," + Translation.y.ToString() + "," + Translation.z.ToString() + "));";
        }

        public override void DrawGUIProperty ()
		{
			#if UNITY_EDITOR
			EditorGUILayout.BeginVertical();

			uiTranslation = EditorGUILayout.Vector3Field("Translation: ", uiTranslation);
			EditorGUILayout.EndVertical();
			#endif
		}

		public override void ApplyGUI ()
		{
			Translation = uiTranslation;
			TextInList = "Jump to position (" + Translation.x.ToString() + "; " + Translation.y.ToString() + ")";
		}
		
		public override void ResetGUI ()
		{
			uiTranslation = Translation;
		}
    }
}