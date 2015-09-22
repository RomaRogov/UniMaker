using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class GMakerObject : MonoBehaviour
	{
		[Serializable]
		public class EventInstance
		{
			public EventTypes Type;
			public List<ActionBase> Actions = new List<ActionBase>();
			
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
			ExecuteEventIfExists(EventTypes.EventMouse);
		}

		void Update ()
		{
		
		}

		private void ExecuteEventIfExists(EventTypes type)
		{
			EventInstance needEvent = Events.Find(x => x.Type == type);
			if (needEvent != null)
			{
				List<bool> blocks = new List<bool>() { true };
				for (int i = 0; i < needEvent.Actions.Count; i++)
				{
					if (needEvent.Actions[i].Type == ActionTypes.EndBlock)
					{
						if (blocks.Count > 1)
						{
							blocks.RemoveAt(blocks.Count-1);
							continue;
						}
					}
					if (!blocks[blocks.Count-1])
					{
						continue;
					}
					if (needEvent.Actions[i].Type == ActionTypes.StartBlock)
					{
						blocks.Add(blocks[blocks.Count-1]);
						continue;
					}
					if (blocks[blocks.Count-1])
					{
						blocks[blocks.Count-1] = needEvent.Actions[i].Execute(this);
					}

				}
			}
		}
	}
}