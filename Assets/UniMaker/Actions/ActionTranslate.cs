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
        public string X;
        public string Y;
        public string Z;

        public string uiX;
        public string uiY;
        public string uiZ;

        public ActionTranslate():base(ActionTypes.Translate)
        {
            Content = FormContent();
            Options = new JSONObject();
            Options.AddField("type", Type.ToString());
            Options.AddField("x", "0f");
            Options.AddField("y", "0f");
            Options.AddField("z", "0f");
        }

        public override void SetOptionsAndContent(string options, string content)
        {
            Options = new JSONObject(options);
            uiX = X = Options.GetField("x").str;
            uiY = Y = Options.GetField("y").str;
            uiZ = Z = Options.GetField("z").str;
            Content = FormContent();
        }

        protected override string FormContent()
        {
            return doubleTabSpaces + "transform.Translate(new Vector3((float)" + X + ",(float)" + Y + ",(float)" + Z + "));";
        }

        protected override string FormText()
        {
            return "Translate to (" + X + "; " + Y + "; " + Z + ")";
        }

        public override void DrawGUIProperty ()
		{
			#if UNITY_EDITOR
			EditorGUILayout.BeginVertical();
            
            uiX = EditorGUILayout.TextField("x: ", uiX);
            uiY = EditorGUILayout.TextField("y: ", uiY);
            uiZ = EditorGUILayout.TextField("z: ", uiZ);
            EditorGUILayout.EndVertical();
			#endif
		}

		public override void ApplyGUI ()
		{
            X = uiX;
            Y = uiY;
            Z = uiZ;

            Options.SetField("x", X);
            Options.SetField("y", Y);
            Options.SetField("z", Z);
            Content = FormContent();
        }
		
		public override void ResetGUI ()
		{
            uiX = X;
            uiY = Y;
            uiZ = Z;
        }
    }
}