namespace UniMaker
{
	public enum EventTypes
	{
        None = 0,
		Start,
		Update,

        /* KEY PRESSED EVENTS */
        LeftKeyPressed,
        RightKeyPressed,
        UpKeyPressed,
        DownKeyPressed,

        CtrlKeyPressed,
        AltKeyPressed,
        ShiftKeyPressed,
        SpaceKeyPressed,
        EnterKeyPressed,

        BackspaceKeyPressed,
        EscapeKeyPressed,
        HomeKeyPressed,
        EndKeyPressed,
        PageUpKeyPressed,
        PageDownKeyPressed,
        DeleteKeyPressed,
        InsertKeyPressed,

        AnyKeyPressed,
        NoKeyPressed,

        /* KEY DOWN EVENTS */
        LeftKeyDown,
        RightKeyDown,
        UpKeyDown,
        DownKeyDown,

        CtrlKeyDown,
        AltKeyDown,
        ShiftKeyDown,
        SpaceKeyDown,
        EnterKeyDown,

        BackspaceKeyDown,
        EscapeKeyDown,
        HomeKeyDown,
        EndKeyDown,
        PageUpKeyDown,
        PageDownKeyDown,
        DeleteKeyDown,
        InsertKeyDown,

        AnyKeyDown,
        NoKeyDown,

        /* KEY UP EVENTS */
        LeftKeyUp,
        RightKeyUp,
        UpKeyUp,
        DownKeyUp,

        CtrlKeyUp,
        AltKeyUp,
        ShiftKeyUp,
        SpaceKeyUp,
        EnterKeyUp,

        BackspaceKeyUp,
        EscapeKeyUp,
        HomeKeyUp,
        EndKeyUp,
        PageUpKeyUp,
        PageDownKeyUp,
        DeleteKeyUp,
        InsertKeyUp,

        AnyKeyUp,
        NoKeyUp
    }
}