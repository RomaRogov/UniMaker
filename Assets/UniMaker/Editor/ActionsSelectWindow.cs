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

		private Vector2 scrollValue = Vector2.zero;

		private Dictionary<ActionTabTypes, ActionTabTypes> tabs = new Dictionary<ActionTabTypes, ActionTabTypes>() {
			{ ActionTabTypes.TabMove, ActionTabTypes.TabMoveActive },
			{ ActionTabTypes.TabMainFirst, ActionTabTypes.TabMainFirstActive },
			{ ActionTabTypes.TabMainSecond, ActionTabTypes.TabMainSecondActive },
			{ ActionTabTypes.TabControl, ActionTabTypes.TabControlActive },
			{ ActionTabTypes.TabScore, ActionTabTypes.TabScoreActive },
			{ ActionTabTypes.TabExtra, ActionTabTypes.TabExtraActive }
		};
		private ActionTabTypes selectedTab = ActionTabTypes.TabMove;

        [MenuItem("UniMaker/Actions Selector")]
		static void Init()
		{
			ActionsSelectWindow wnd = EditorWindow.GetWindow<ActionsSelectWindow>("Actions");
			wnd.Show();
		}
		
		void OnGUI()
		{
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			scrollValue = EditorGUILayout.BeginScrollView(scrollValue, GUI.skin.box);
			switch (selectedTab)
			{
				case ActionTabTypes.TabMove: 		DrawMoveTab(); 			break;
				case ActionTabTypes.TabMainFirst: 	DrawMainFirstTab(); 	break;
				case ActionTabTypes.TabMainSecond: 	DrawMainSecondTab(); 	break;
				case ActionTabTypes.TabControl: 	DrawControlTab(); 		break;
				case ActionTabTypes.TabScore: 		DrawScoreTab(); 		break;
				case ActionTabTypes.TabExtra: 		DrawExtraTab(); 		break;
			}
			EditorGUILayout.EndScrollView();
			GUILayout.Space(-5f);
			EditorGUILayout.BeginVertical();
			foreach (KeyValuePair<ActionTabTypes, ActionTabTypes> kvp in tabs)
			{
				Texture tex = IconCacher.GetIcon<ActionTabTypes>(selectedTab == kvp.Key ? kvp.Value : kvp.Key);
				if (GUILayout.Button(tex, GUI.skin.label))
				{
					selectedTab = kvp.Key;
				}
				GUILayout.Space(-3f);
			}
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
			GUILayout.BeginVertical();
			DrawTypeGrid("Move: ", move_moveTypes);
			DrawTypeGrid("Jump: ", move_jumpTypes);
			DrawTypeGrid("Step: ", move_stepTypes);
			GUILayout.EndVertical();
		}

		/* MAIN, SET 1 TAB */

		private List<ActionTypes> mainFirst_instances = new List<ActionTypes>() {
			ActionTypes.CreateInstance,
			ActionTypes.CreateMoving,
			ActionTypes.CreateRandom,
			ActionTypes.ChangeInstance, 
			ActionTypes.DestroyInstance,
			ActionTypes.DestroyAtPosition
		};

		private List<ActionTypes> mainFirst_sprites = new List<ActionTypes>() {
			ActionTypes.ChangeSprite,
			ActionTypes.TransformSprite,
			ActionTypes.ColourSprite
		};

		private List<ActionTypes> mainFirst_sounds = new List<ActionTypes>() {
			ActionTypes.PlaySound,
			ActionTypes.StopSound,
			ActionTypes.CheckSound
		};

		private List<ActionTypes> mainFirst_scenes = new List<ActionTypes>() {
			ActionTypes.PreviousScene,
			ActionTypes.NextScene,
			ActionTypes.RestartScene,
			ActionTypes.DifferentScene,
			ActionTypes.CheckPreviousScene,
			ActionTypes.CheckNextScene
		};

		private void DrawMainFirstTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Objects: ", mainFirst_instances);
			DrawTypeGrid("Sprite: ", mainFirst_sprites);
			DrawTypeGrid("Sounds: ", mainFirst_sounds);
			DrawTypeGrid("Scenes: ", mainFirst_scenes);
			GUILayout.EndVertical();
		}

		/* MAIN, SET 2 TAB */

		private List<ActionTypes> mainSecond_timing = new List<ActionTypes>() {
			ActionTypes.SetAlarm
		};

		private List<ActionTypes> mainSecond_info = new List<ActionTypes>() {
			ActionTypes.DisplayMessage,
			ActionTypes.URLOpen
		};

		private List<ActionTypes> mainSecond_game = new List<ActionTypes>() {
			ActionTypes.RestartGame,
			ActionTypes.EndGame
		};

		private void DrawMainSecondTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Timing: ", mainSecond_timing);
			DrawTypeGrid("Info: ", mainSecond_info);
			DrawTypeGrid("Game: ", mainSecond_game);
			GUILayout.EndVertical();
		}

		/* CONTROL TAB */

		private List<ActionTypes> control_questions = new List<ActionTypes>() {
			ActionTypes.CheckEmpty,
			ActionTypes.CheckCollision,
			ActionTypes.CheckObject,
			ActionTypes.TestInstanceCount,
			ActionTypes.TestChance,
			ActionTypes.CheckQuestion,
			ActionTypes.CheckMouse,
			ActionTypes.CheckGrid
		};

		private List<ActionTypes> control_other = new List<ActionTypes>() {
			ActionTypes.StartBlock,
			ActionTypes.Else,
			ActionTypes.ExitEvent,
			ActionTypes.EndBlock,
			ActionTypes.Repeat
		};

		private List<ActionTypes> control_code = new List<ActionTypes>() {
			ActionTypes.ExecuteCode,
			ActionTypes.ExecuteScript,
			ActionTypes.Comment
		};

		private List<ActionTypes> control_variables = new List<ActionTypes>() {
			ActionTypes.SetVariable,
			ActionTypes.TestVariable
		};

		private void DrawControlTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Questions: ", control_questions);
			DrawTypeGrid("Other: ", control_other);
			DrawTypeGrid("Code: ", control_code);
			DrawTypeGrid("Variables: ", control_variables);
			GUILayout.EndVertical();
		}

		/* SCORE TAB */

		private List<ActionTypes> score_score = new List<ActionTypes>() {
			ActionTypes.SetScore,
			ActionTypes.TestScore
		};

		private List<ActionTypes> score_lives = new List<ActionTypes>() {
			ActionTypes.SetLives,
			ActionTypes.TestLives
		};

		private List<ActionTypes> score_health = new List<ActionTypes>() {
			ActionTypes.SetHealth,
			ActionTypes.TestHealth
		};

		private void DrawScoreTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Score: ", score_score);
			DrawTypeGrid("Lives: ", score_lives);
			DrawTypeGrid("Health: ", score_health);
			GUILayout.EndVertical();
		}

		/* EXTRA TAB */

		private List<ActionTypes> extra_other = new List<ActionTypes>() {
			ActionTypes.SetCursor,
		};

		private void DrawExtraTab()
		{
			GUILayout.BeginVertical();
			DrawTypeGrid("Other: ", extra_other);
			GUILayout.EndVertical();
		}

		/* END OF TAB LIST */

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