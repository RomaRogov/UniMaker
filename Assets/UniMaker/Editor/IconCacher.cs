using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class IconCacher
	{
		private const string iconFolderName = "TypeIcons";

		private static IconCacher instance;
		internal static IconCacher Instance
		{
			get
			{
				instance = new IconCacher();
				return instance;
			}
		}

		private Dictionary<EventTypes, Texture> EventIcons;
		private Dictionary<ActionTypes, Texture> ActionIcons;

		public IconCacher()
		{
			EventIcons = new Dictionary<EventTypes, Texture>();
			ActionIcons = new Dictionary<ActionTypes, Texture>();
		}

		internal static Texture GetEventIcon(EventTypes type)
		{
			if (!Instance.EventIcons.ContainsKey(type))
			{
				Texture icon = (Texture)EditorGUIUtility.Load(iconFolderName + "\\" + type.ToString() + ".png");
				if (icon != null)
				{
					Instance.EventIcons.Add(type, icon);
					return icon;
				}
				else return null;
			}
			return Instance.EventIcons[type];
		}

		internal static Texture GetActionIcon(ActionTypes type)
		{
			if (!Instance.ActionIcons.ContainsKey(type))
			{
				Texture icon = (Texture)EditorGUIUtility.Load(iconFolderName + "\\" + type.ToString() + ".png");
				if (icon != null)
				{
					Instance.ActionIcons.Add(type, icon);
					return icon;
				}
				else return null;
			}
			return Instance.ActionIcons[type];
		}

	}
}