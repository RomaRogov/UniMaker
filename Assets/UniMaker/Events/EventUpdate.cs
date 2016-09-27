using UnityEngine;
using System.Collections;

namespace UniMaker.Events
{
    public class EventUpdate : UniEvent
    {
        public EventUpdate():base(EventTypes.Update)
        {
            Priority = 5;
        }

        protected override string FormText()
        {
            return "Update";
        }

        protected override string FormHeader()
        {
            return "protected override void Update() { base.Update(); ";
        }
    }
}