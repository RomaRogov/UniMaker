using UnityEngine;
using System.Collections;

namespace UniMaker.Events
{
    public class EventKeyDown : UniEvent
    {
        protected string Key;

        public EventKeyDown(EventTypes type):base(type)
        {
            Priority = 10;
        }

        protected override string FormText()
        {
            return Key + " Down";
        }

        protected override string FormHeader()
        {
            return "protected override void " + Key + "KeyDown() {";
        }
    }

    public class EventLeftKeyDown : EventKeyDown { public EventLeftKeyDown() : base(EventTypes.LeftKeyDown) { Key = "Left"; } }
    public class EventRightKeyDown : EventKeyDown { public EventRightKeyDown() : base(EventTypes.RightKeyDown) { Key = "Right"; } }
    public class EventUpKeyDown : EventKeyDown { public EventUpKeyDown() : base(EventTypes.UpKeyDown) { Key = "Up"; } }
    public class EventDownKeyDown : EventKeyDown { public EventDownKeyDown() : base(EventTypes.DownKeyDown) { Key = "Down"; } }

    public class EventCtrlKeyDown : EventKeyDown { public EventCtrlKeyDown() : base(EventTypes.CtrlKeyDown) { Key = "Ctrl"; } }
    public class EventAltKeyDown : EventKeyDown { public EventAltKeyDown() : base(EventTypes.AltKeyDown) { Key = "Alt"; } }
    public class EventShiftKeyDown : EventKeyDown { public EventShiftKeyDown() : base(EventTypes.ShiftKeyDown) { Key = "Shift"; } }
    public class EventSpaceKeyDown : EventKeyDown { public EventSpaceKeyDown() : base(EventTypes.SpaceKeyDown) { Key = "Space"; } }
    public class EventEnterKeyDown : EventKeyDown { public EventEnterKeyDown() : base(EventTypes.EnterKeyDown) { Key = "Enter"; } }

    public class EventBackspaceKeyDown : EventKeyDown { public EventBackspaceKeyDown() : base(EventTypes.BackspaceKeyDown) { Key = "Backspace"; } }
    public class EventEscapeKeyDown : EventKeyDown { public EventEscapeKeyDown() : base(EventTypes.EscapeKeyDown) { Key = "Escape"; } }
    public class EventHomeKeyDown : EventKeyDown { public EventHomeKeyDown() : base(EventTypes.HomeKeyDown) { Key = "Home"; } }
    public class EventEndKeyDown : EventKeyDown { public EventEndKeyDown() : base(EventTypes.EndKeyDown) { Key = "End"; } }
    public class EventPageUpKeyDown : EventKeyDown { public EventPageUpKeyDown() : base(EventTypes.PageUpKeyDown) { Key = "PageUp"; } }
    public class EventPageDownKeyDown : EventKeyDown { public EventPageDownKeyDown() : base(EventTypes.PageDownKeyDown) { Key = "PageDown"; } }
    public class EventDeleteKeyDown : EventKeyDown { public EventDeleteKeyDown() : base(EventTypes.DeleteKeyDown) { Key = "Delete"; } }
    public class EventInsertKeyDown : EventKeyDown { public EventInsertKeyDown() : base(EventTypes.InsertKeyDown) { Key = "Insert"; } }

    public class EventAnyKeyDown : EventKeyDown { public EventAnyKeyDown() : base(EventTypes.AnyKeyDown) { Key = "Any"; } }
    public class EventNoKeyDown : EventKeyDown { public EventNoKeyDown() : base(EventTypes.NoKeyDown) { Key = "No"; } }
}