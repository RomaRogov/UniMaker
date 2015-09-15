using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class GMakerObject : MonoBehaviour
	{
		[Serializable]
		public class ActionInstance
		{
			public ActionTypes Type;

			public ActionInstance(ActionTypes type)
			{
				Type = type;
			}
		}

		[Serializable]
		public class EventInstance
		{
			public EventTypes Type;
			public List<ActionInstance> Actions = new List<ActionInstance>();
			
			public EventInstance(EventTypes type)
			{
				Type = type;
			}
		}

		[HideInInspector]
		public int SelectedEventIndex = 0;
		public List<EventInstance> Events = new List<EventInstance>();
		public EventInstance SelectedEvent { get { return Events[SelectedEventIndex]; } }

		void Start ()
		{
		
		}

		void Update ()
		{
		
		}
	}
}