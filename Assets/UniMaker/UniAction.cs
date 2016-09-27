using UnityEngine;
using System;
using System.Collections;

namespace UniMaker.Actions
{
	public class UniAction
	{
		public ActionTypes Type;
        public JSONObject Options;
        public string Content;
		public string TextInList { get { return FormText(); } }

        protected string doubleTabSpaces = UniEditorAbstract.TabSpaces + UniEditorAbstract.TabSpaces;

        public UniAction(ActionTypes type)
		{
            Type = type;
		}

        protected virtual string FormContent() { return ""; }
        protected virtual string FormText() { return ""; }

        public virtual void SetOptionsAndContent(string options, string content) { }
        public virtual void DrawGUIProperty() { }
        public virtual void ApplyGUI() { }
        public virtual void ResetGUI() { }

        public static UniAction GetActionInstanceByType(ActionTypes type)
        {
            return (UniAction)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Actions.Action" + type.ToString()).Unwrap();
        }

        public static UniAction GetActionInstanceByType(string type)
        {
            return (UniAction)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Actions.Action" + type).Unwrap();
        }
    }
}