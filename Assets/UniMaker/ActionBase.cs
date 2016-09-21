using UnityEngine;
using System;
using System.Collections;

namespace UniMaker.Actions
{
	public class ActionBase
	{
		public ActionTypes Type;
        public JSONObject Options;
        public string Content;
		public string TextInList = "BASE ACTION";

        protected string doubleTabSpaces = UniEditorAbstract.TabSpaces + UniEditorAbstract.TabSpaces;

        public ActionBase(ActionTypes type)
		{
            Type = type;
		}

        protected virtual string FormContent() { return ""; }
        protected virtual string FormText() { return ""; }

        public virtual void SetOptionsAndContent(string options, string content) { }
        public virtual void DrawGUIProperty() { }
        public virtual void ApplyGUI() { }
        public virtual void ResetGUI() { }
	}
}