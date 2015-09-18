namespace UniMaker
{
	public enum ActionTypes
	{
		None,

		/* MOVE ACTIONS */

		//Move
		MoveFixed,
		MoveFree,
		MoveTowards,
		SpeedHorizontal,
		SpeedVertical,
		SetGravity,
		ReverseHorizontal,
		ReverseVertical,
		SetFriction,

		//Jump
		JumpToPosition,
		JumpToStart,
		JumpToRandom,
		AlignToGrid,
		WrapScreen,
		MoveToContact,
		Bounce,

		//Planned to use animations instead of paths. Sorry

		//Steps
		StepTowards,
		StepAvoid, //How to realize avoiding system?

		/* MAIN, SET 1 */

		//Instances
		CreateInstance,
		CreateMoving,
		CreateRandom,
		ChangeInstance, //Destroy previous, create new. Make some flags for realize not sending destroy or create event feature.
		DestroyInstance,
		DestroyAtPosition,

		//Sprites
		ChangeSprite,
		TransformSprite,
		ColourSprite,

		//Sounds
		PlaySound,
		StopSound,
		CheckSound,

		//Rooms (Scenes)
		PreviousScene,
		NextScene,
		RestartScene,
		DifferentScene,
		CheckPreviousScene,
		CheckNextScene,

		/* MAIN, SET 2 */

		//Timing
		SetAlarm,
		//TimeLine functional? IDK, bullshit, IMO, animator can replace that

		//Info
		DisplayMessage, //UnityUI or some special fab?
		URLOpen,

		//Game
		RestartGame,
		EndGame,
		//SaveGame functional? PlayerPrefs can make all work

		//Resources
		//It's advanced stuff that any Unity3D user can do if he wish

		/* CONTROL */

		//Questions
		CheckEmpty,
		CheckCollision,
		CheckObject,
		TestInstanceCount,
		TestChance,
		CheckQuestion,
		//TestExpression, //TestVariable is ok for it
		CheckMouse,
		CheckGrid,

		//Other
		StartBlock,
		EndBlock,
		Else,
		Repeat,
		ExitEvent,
		//CallParentEvent, //Parent by hierarchy? Oh, no, fuck it too.

		//Code
		ExecuteCode, //Adds component with C# event and code, that runs with this action
		ExecuteScript, //Select MonoBehaviour for adding as component
		Comment,

		//Variables
		SetVariable, //Create in GMakerObject dictionary <string,GMVar[type,intval,strval,boolval]> with custom vars!
		TestVariable, //Offer user to check greater/smaller/equals or true/false
		//DrawVariable, //Sure? How?

		/* SCORE */

		//Score

		SetScore,
		TestScore,
		//DrawScore //Same as DrawVariable
		//ClearHighscore //Maybe will be realized later

		//Lives

		SetLives,
		TestLives,
		//DrawLives //Hm.
		//DrawLifeImages //HmHmHm.

		//Health

		SetHealth,
		TestHealth,
		//DrawHealth,
		//ScoreCaption,

		/* EXTRA */

		SetCursor,

		//Give particles job to Mecanim, ok?

		//Draw actions not situable
	}
}