using UnityEngine;
using System;
using System.Collections;

namespace UniMaker
{
	[Serializable]
	public class ActionBase
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

		internal virtual JSONObject GetJSON()
		{
			JSONObject myJson = new JSONObject();
			myJson.AddField("Type", Type.ToString());
			myJson.AddField("TextInList", TextInList);
			return myJson;
		}

		internal virtual void ParseJSON(JSONObject input)
		{
			Type = (ActionTypes)Enum.Parse(typeof(ActionTypes), input["Type"].str);
			TextInList = input["TextInList"].str;
		}
	}
}