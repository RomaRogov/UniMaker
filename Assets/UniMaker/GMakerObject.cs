using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	[ExecuteInEditMode]
	public class GMakerObject : MonoBehaviour
	{
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
		public string savedJSON;

		public List<EventInstance> Events = new List<EventInstance>();
		public EventInstance SelectedEvent { get { return Events[SelectedEventIndex]; } }

		private void Awake()
		{
			LoadDataFromJSON();
		}

		void Start ()
		{
			if (Application.isPlaying)
			{
				ExecuteEventIfExists(EventTypes.EventMouse);
			}
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

		public void SaveDataToJSON()
		{
			JSONObject jEvents = new JSONObject();
			foreach (EventInstance ev in Events)
			{
				JSONObject jEvent = new JSONObject();
				jEvent.AddField("Type", ev.Type.ToString());
				JSONObject jActionList = new JSONObject();
				foreach(ActionBase action in ev.Actions)
				{
					jActionList.Add(action.GetJSON());
				}

				jEvent.AddField("Actions", jActionList);
				jEvents.Add(jEvent);
			}
			savedJSON = jEvents.ToString();
		}

		public void LoadDataFromJSON()
		{
			if (string.IsNullOrEmpty(savedJSON))
			{
				return;
			}

			JSONObject obj = new JSONObject(savedJSON);
			if (obj.IsNull)
			{
				return;
			}
			Events = obj.list.ConvertAll<EventInstance>(jEvent => 
			{
				EventInstance ev = new EventInstance((EventTypes)Enum.Parse(typeof(EventTypes), jEvent["Type"].str));
				if (jEvent["Actions"].IsNull)
				{
					ev.Actions = new List<ActionBase>();
				}
				else
				{
					ev.Actions = jEvent["Actions"].list.ConvertAll<ActionBase>(jAction =>
					{
						ActionBase action = (ActionBase)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Action" + jAction["Type"].str).Unwrap();
						action.ParseJSON(jAction);
						return action;
					});
				}
				return ev;
			});
		}
	}
}