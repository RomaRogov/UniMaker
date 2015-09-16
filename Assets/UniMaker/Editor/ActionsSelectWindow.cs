using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.Collections.Generic;

namespace UniMaker
{
	public class ActionsSelectWindow : EditorWindow
	{
		private const int itemSize = 24;

		//private Vector2 scrollValue = Vector2.zero;

		private List<ActionTabTypes> normalTabs = new List<ActionTabTypes>() {
			ActionTabTypes.TabMove,
			ActionTabTypes.TabMainFirst,
			ActionTabTypes.TabMainSecond,
			ActionTabTypes.TabControl,
			ActionTabTypes.TabScore,
			ActionTabTypes.TabExtra
		};

		private List<ActionTabTypes> activelTabs = new List<ActionTabTypes>() {
			ActionTabTypes.TabMoveActive,
			ActionTabTypes.TabMainFirstActive,
			ActionTabTypes.TabMainSecondActive,
			ActionTabTypes.TabControlActive,
			ActionTabTypes.TabScoreActive,
			ActionTabTypes.TabExtraActive
		};
        
        [MenuItem("UniMaker/Actions Selector")]
		static void Init()
		{
			ActionsSelectWindow wnd = EditorWindow.GetWindow<ActionsSelectWindow>("Actions");
			wnd.Show();
		}
		
		void OnGUI()
		{
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DrawMoveTab();
			GUILayout.Space(-5f);
			EditorGUILayout.BeginVertical();
			normalTabs.ForEach(x => 
			{
				Texture tex = IconCacher.GetIcon<ActionTabTypes>(x);
				GUILayout.Button(tex, GUI.skin.label);
				GUILayout.Space(-3f);
			});
			EditorGUILayout.EndVertical();
			EditorGUILayout.EndHorizontal();
		}

		/* MOVE TAB */

		private List<ActionTypes> move_moveTypes = new List<ActionTypes>() {
			ActionTypes.MoveFixed,
			ActionTypes.MoveFree,
			ActionTypes.MoveTowards,
			ActionTypes.SpeedHorizontal,
			ActionTypes.SpeedVertical,
			ActionTypes.SetGravity,
			ActionTypes.ReverseHorizontal,
			ActionTypes.ReverseVertical,
			ActionTypes.SetFriction
		};
		private List<ActionTypes> move_jumpTypes = new List<ActionTypes>() {
			ActionTypes.JumpToPosition,
			ActionTypes.JumpToStart,
			ActionTypes.JumpToRandom,
			ActionTypes.AlignToGrid,
			ActionTypes.WrapScreen,
			ActionTypes.MoveToContact,
			ActionTypes.Bounce
        };
        private List<ActionTypes> move_stepTypes = new List<ActionTypes>() {
			ActionTypes.StepTowards,
			ActionTypes.StepAvoid
        };
        
        private void DrawMoveTab()
		{
			GUILayout.BeginVertical(GUI.skin.box);
			DrawTypeGrid("Move: ", move_moveTypes);
			DrawTypeGrid("Jump: ", move_jumpTypes);
			DrawTypeGrid("Step: ", move_stepTypes);
			GUILayout.EndVertical();
		}

		/* MAIN, SET 1 TAB */

		private int DrawTypeGrid(string title, List<ActionTypes> listToDraw)
		{
			GUILayout.Label(title);
			return GUILayout.SelectionGrid(999, listToDraw.ConvertAll(x => {return IconCacher.GetIcon<ActionTypes>(x);}).ToArray(), 3 );
		}

		private static void DrawLabelInCenter(string text)
		{
			EditorGUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.LabelField(text, GUI.skin.box);
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndVertical();
		}
	}
}