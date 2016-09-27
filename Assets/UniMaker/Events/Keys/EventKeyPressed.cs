using UnityEngine;
using System.Collections;

namespace UniMaker.Events
{
    public class EventKeyPressed : UniEvent
    {
        protected string Key;

        public EventKeyPressed(EventTypes type):base(type)
        {
            Priority = 10;
        }

        protected override string FormText()
        {
            return Key + " pressed";
        }

        protected override string FormHeader()
        {
            return "protected override void " + Key + "KeyPressed() {";
        }
    }

    public class EventLeftKeyPressed : EventKeyPressed { public EventLeftKeyPressed() : base(EventTypes.LeftKeyPressed) { Key = "Left"; } }
    public class EventRightKeyPressed : EventKeyPressed { public EventRightKeyPressed() : base(EventTypes.RightKeyPressed) { Key = "Right"; } }
    public class EventUpKeyPressed : EventKeyPressed { public EventUpKeyPressed() : base(EventTypes.UpKeyPressed) { Key = "Up"; } }
    public class EventDownKeyPressed : EventKeyPressed { public EventDownKeyPressed() : base(EventTypes.DownKeyPressed) { Key = "Down"; } }

    public class EventCtrlKeyPressed : EventKeyPressed { public EventCtrlKeyPressed() : base(EventTypes.CtrlKeyPressed) { Key = "Ctrl"; } }
    public class EventAltKeyPressed : EventKeyPressed { public EventAltKeyPressed() : base(EventTypes.AltKeyPressed) { Key = "Alt"; } }
    public class EventShiftKeyPressed : EventKeyPressed { public EventShiftKeyPressed() : base(EventTypes.ShiftKeyPressed) { Key = "Shift"; } }
    public class EventSpaceKeyPressed : EventKeyPressed { public EventSpaceKeyPressed() : base(EventTypes.SpaceKeyPressed) { Key = "Space"; } }
    public class EventEnterKeyPressed : EventKeyPressed { public EventEnterKeyPressed() : base(EventTypes.EnterKeyPressed) { Key = "Enter"; } }

    public class EventBackspaceKeyPressed : EventKeyPressed { public EventBackspaceKeyPressed() : base(EventTypes.BackspaceKeyPressed) { Key = "Backspace"; } }
    public class EventEscapeKeyPressed : EventKeyPressed { public EventEscapeKeyPressed() : base(EventTypes.EscapeKeyPressed) { Key = "Escape"; } }
    public class EventHomeKeyPressed : EventKeyPressed { public EventHomeKeyPressed() : base(EventTypes.HomeKeyPressed) { Key = "Home"; } }
    public class EventEndKeyPressed : EventKeyPressed { public EventEndKeyPressed() : base(EventTypes.EndKeyPressed) { Key = "End"; } }
    public class EventPageUpKeyPressed : EventKeyPressed { public EventPageUpKeyPressed() : base(EventTypes.PageUpKeyPressed) { Key = "PageUp"; } }
    public class EventPageDownKeyPressed : EventKeyPressed { public EventPageDownKeyPressed() : base(EventTypes.PageDownKeyPressed) { Key = "PageDown"; } }
    public class EventDeleteKeyPressed : EventKeyPressed { public EventDeleteKeyPressed() : base(EventTypes.DeleteKeyPressed) { Key = "Delete"; } }
    public class EventInsertKeyPressed : EventKeyPressed { public EventInsertKeyPressed() : base(EventTypes.InsertKeyPressed) { Key = "Insert"; } }

    public class EventAnyKeyPressed : EventKeyPressed { public EventAnyKeyPressed() : base(EventTypes.AnyKeyPressed) { Key = "Any"; } }
    public class EventNoKeyPressed : EventKeyPressed { public EventNoKeyPressed() : base(EventTypes.NoKeyPressed) { Key = "No"; } }
}