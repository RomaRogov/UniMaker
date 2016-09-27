using UnityEngine;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UniMaker.Actions
{
	public class ActionTranslate : UniAction
	{
		public Vector3 uiTranslation;
		public Vector3 Translation;

        public ActionTranslate():base(ActionTypes.Translate)
        {
            Translation = new Vector3();
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

        protected override string FormContent()
        {
            return doubleTabSpaces + "transform.Translate(new Vector3(" + Translation.x.ToString() + "f," + Translation.y.ToString() + "f," + Translation.z.ToString() + "f));";
        }

        protected override string FormText()
        {
            return "Translate to (" + Translation.x.ToString() + "; " + Translation.y.ToString() + "; " + Translation.z.ToString() + ")";
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
            Options.SetField("x", Translation.x);
            Options.SetField("y", Translation.y);
            Options.SetField("z", Translation.z);
            Content = FormContent();
        }
		
		public override void ResetGUI ()
		{
			uiTranslation = Translation;
		}
    }
}