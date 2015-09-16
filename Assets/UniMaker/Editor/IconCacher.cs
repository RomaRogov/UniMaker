using UnityEngine;
using UnityEditor;
using System;
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
				if (instance == null)
				{
					instance = new IconCacher();
				}
				return instance;
			}
		}


		private Dictionary<string, Dictionary<string, Texture>> Caches;

		public IconCacher()
		{
			Caches = new Dictionary<string, Dictionary<string, Texture>>();
		}

		internal static Texture GetIcon<T>(T type)
		{
			string enumType = typeof(T).ToString();
			if (!Instance.Caches.ContainsKey(enumType))
			{
				Instance.Caches.Add(enumType, new Dictionary<string, Texture>());
			}
			if (!Instance.Caches[enumType].ContainsKey(type.ToString()))
			{
				Texture icon = (Texture)EditorGUIUtility.Load(iconFolderName + "\\" + enumType + "\\" + type.ToString() + ".png");
				if (icon != null)
				{
					Instance.Caches[enumType].Add(type.ToString(), icon);
					return icon;
				}
				else return null;
			}
			return Instance.Caches[enumType][type.ToString()];
		}

	}
}