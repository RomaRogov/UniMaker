using UnityEngine;
using System;
using System.Collections;

namespace UniMaker
{
	[Serializable]
	public class ActionBase : ScriptableObject
	{
		public ActionTypes Type;
		public string TextInList = "BASE ACTION";

		public ActionBase(ActionTypes type)
		{
			Type = type;
		}
		
		internal virtual bool Execute(GMakerObject obj)
		{
			//Action-based classes should overload this method to set actions
			Debug.Log("Ececuted " + TextInList);
			return true;
		}

		public virtual void DrawGUIProperty()
		{
			//Action-based classes shoud overload this method to draw and set GUI properties
		}

	}
}