using UniMaker.Actions;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace UniMaker
{
    public class UniEvent
    {
        public EventTypes Type;
        public List<ActionBase> Actions;

        public UniEvent(string options, string content)
        {
            Debug.Log("New event!\nOptions:" + options + "\nContent: " + content);

            JSONObject eventOptionsJSON = new JSONObject(options);
            Type = (EventTypes)Enum.Parse(typeof(EventTypes), eventOptionsJSON.GetField("type").str);

            Actions = new List<ActionBase>();

            StringReader strReader = new StringReader(content);
            string currentLine = null;
            string actionOptions = null;
            string actionContent = "";
            bool readingActionContent = false;

            while ((currentLine = strReader.ReadLine()) != null)
            {
                currentLine = currentLine.TrimStart(new char[] { ' ', '\t' });

                if (currentLine.StartsWith("//ACTION"))
                {
                    actionOptions = currentLine.Substring(currentLine.IndexOf('%') + 1);
                    actionContent = "";
                    readingActionContent = true;
                    continue;
                }

                if (currentLine.StartsWith("//ENDACTION"))
                {
                    JSONObject actionOptionsJSON = new JSONObject(actionOptions);
                    ActionBase newAction = (ActionBase)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Actions.Action" + actionOptionsJSON.GetField("type").str).Unwrap();
                    newAction.SetOptionsAndContent(actionOptions, actionContent);
                    Actions.Add(newAction);
                }

                if (readingActionContent)
                {
                    actionContent += currentLine + "\n";
                }
            }

            strReader.Close();
        }
    }
}
