using UnityEngine;
using System.Collections;

namespace UniMaker.Events
{
    public class EventKeyUp : UniEvent
    {
        protected string Key;

        public EventKeyUp(EventTypes type):base(type)
        {
            Priority = 10;
        }

        protected override string FormText()
        {
            return Key + " Up";
        }

        protected override string FormHeader()
        {
            return "protected override void " + Key + "KeyUp() {";
        }
    }

    public class EventLeftKeyUp : EventKeyUp { public EventLeftKeyUp() : base(EventTypes.LeftKeyUp) { Key = "Left"; } }
    public class EventRightKeyUp : EventKeyUp { public EventRightKeyUp() : base(EventTypes.RightKeyUp) { Key = "Right"; } }
    public class EventUpKeyUp : EventKeyUp { public EventUpKeyUp() : base(EventTypes.UpKeyUp) { Key = "Up"; } }
    public class EventDownKeyUp : EventKeyUp { public EventDownKeyUp() : base(EventTypes.DownKeyUp) { Key = "Down"; } }

    public class EventCtrlKeyUp : EventKeyUp { public EventCtrlKeyUp() : base(EventTypes.CtrlKeyUp) { Key = "Ctrl"; } }
    public class EventAltKeyUp : EventKeyUp { public EventAltKeyUp() : base(EventTypes.AltKeyUp) { Key = "Alt"; } }
    public class EventShiftKeyUp : EventKeyUp { public EventShiftKeyUp() : base(EventTypes.ShiftKeyUp) { Key = "Shift"; } }
    public class EventSpaceKeyUp : EventKeyUp { public EventSpaceKeyUp() : base(EventTypes.SpaceKeyUp) { Key = "Space"; } }
    public class EventEnterKeyUp : EventKeyUp { public EventEnterKeyUp() : base(EventTypes.EnterKeyUp) { Key = "Enter"; } }

    public class EventBackspaceKeyUp : EventKeyUp { public EventBackspaceKeyUp() : base(EventTypes.BackspaceKeyUp) { Key = "Backspace"; } }
    public class EventEscapeKeyUp : EventKeyUp { public EventEscapeKeyUp() : base(EventTypes.EscapeKeyUp) { Key = "Escape"; } }
    public class EventHomeKeyUp : EventKeyUp { public EventHomeKeyUp() : base(EventTypes.HomeKeyUp) { Key = "Home"; } }
    public class EventEndKeyUp : EventKeyUp { public EventEndKeyUp() : base(EventTypes.EndKeyUp) { Key = "End"; } }
    public class EventPageUpKeyUp : EventKeyUp { public EventPageUpKeyUp() : base(EventTypes.PageUpKeyUp) { Key = "PageUp"; } }
    public class EventPageDownKeyUp : EventKeyUp { public EventPageDownKeyUp() : base(EventTypes.PageDownKeyUp) { Key = "PageDown"; } }
    public class EventDeleteKeyUp : EventKeyUp { public EventDeleteKeyUp() : base(EventTypes.DeleteKeyUp) { Key = "Delete"; } }
    public class EventInsertKeyUp : EventKeyUp { public EventInsertKeyUp() : base(EventTypes.InsertKeyUp) { Key = "Insert"; } }

    public class EventAnyKeyUp : EventKeyUp { public EventAnyKeyUp() : base(EventTypes.AnyKeyUp) { Key = "Any"; } }
    public class EventNoKeyUp : EventKeyUp { public EventNoKeyUp() : base(EventTypes.NoKeyUp) { Key = "No"; } }
}