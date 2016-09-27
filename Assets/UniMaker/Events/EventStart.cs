using UnityEngine;
using System.Collections;

namespace UniMaker.Events
{
    public class EventStart : UniEvent
    {
        public EventStart():base(EventTypes.Start)
        {
            Priority = 1;
        }

        protected override string FormText()
        {
            return "Start";
        }

        protected override string FormHeader()
        {
            return "void Start() {";
        }
    }
}