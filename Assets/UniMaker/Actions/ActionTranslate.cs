using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker.Actions
{
	public class ActionTranslate : ActionBase
	{
		public Vector3 uiTranslation;
		public Vector3 Translation;

        protected override string FormContent()
        {
            return doubleTabSpaces + "transform.Translate(new Vector3(" + Translation.x.ToString() + "," + Translation.y.ToString() + "," + Translation.z.ToString() + "));";
        }

        protected override string FormText()
        {
            return TextInList = "Translate to (" + Translation.x.ToString() + "; " + Translation.y.ToString() + ")";
        }

        public ActionTranslate():base(ActionTypes.Translate) {
            Translation = new Vector3();
            TextInList = FormText();
            Content = FormContent();
            Options = new JSONObject();
            Options.AddField("type", Type.ToString());
            Options.AddField("x", 0f);
            Options.AddField("y", 0f);
            Options.AddField("z", 0f);
        }

        public override void SetOptionsAndContent(string options, string content)
        {
            Options = new JSONObject(options);
            Translation = new Vector3(Options.GetField("x").f, Options.GetField("y").f, Options.GetField("z").f);
            Content = FormContent();
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
			TextInList = "Translate to (" + Translation.x.ToString() + "; " + Translation.y.ToString() + ")";
            Content = FormContent();
        }
		
		public override void ResetGUI ()
		{
			uiTranslation = Translation;
		}
    }
}