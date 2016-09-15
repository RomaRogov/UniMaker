using UnityEngine;
using System;
using System.Collections;

namespace UniMaker.Actions
{
	public class ActionBase
	{
		public ActionTypes Type;
        public string Content;
		public string TextInList = "BASE ACTION";

		public ActionBase(ActionTypes type)
		{
            Debug.Log("New action!\nType:" + type.ToString());
		}

        public virtual void SetOptionsAndContent(string options, string content)
        {
            //Action-based classes shoud overload this method to draw GUI properties
        }

        public virtual void DrawGUIProperty()
		{
			//Action-based classes shoud overload this method to draw GUI properties
		}

		public virtual void ApplyGUI()
		{
			//Action-based classes shoud overload this method to apply GUI properties
		}

		public virtual void ResetGUI()
		{
			//Action-based classes shoud overload this method to reset GUI properties
		}
	}
}