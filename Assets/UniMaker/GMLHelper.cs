using UnityEngine;
using System;
using System.Collections;

namespace UniMaker
{
	public class GMLHelper
	{
		public static void Repeat(int count, Action action)
		{
			for (int i = 0; i < count; i++)
			{
				action();
			}
		}
	}
}