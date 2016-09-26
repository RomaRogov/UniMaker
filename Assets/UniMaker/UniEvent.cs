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
        public JSONObject Options;

        private Dictionary<EventTypes, string> codeFormats = new Dictionary<EventTypes, string>()
        {
            {EventTypes.Start, "void Start() {" },
            {EventTypes.Update, "protected override void Update() { base.Update();" },
            {EventTypes.KeyPressed, "protected override void KeyPressed(KeyCode which) { if (which != {0}) { return; }" },
        };

        public UniEvent(string options, string content)
        {
            Options = new JSONObject(options);
            Type = (EventTypes)Enum.Parse(typeof(EventTypes), Options.GetField("type").str);

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

        public void CombineScript(StreamWriter strWriter)
        {
            string doubleTabSpaces = UniEditorAbstract.TabSpaces + UniEditorAbstract.TabSpaces;

            //Write event data
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + UniEditorAbstract.EventBeginText + "%{\"type\":\"" + Type.ToString() + "\"}");
            //Write method header
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + string.Format(codeFormats[Type], Options.GetField("args").list.ConvertAll<string>(arg => arg.str)));
            //Write actions
            Actions.ForEach(a =>
            {
                //Write action data
                strWriter.WriteLine(doubleTabSpaces + UniEditorAbstract.ActionBeginText + "%" + a.Options.ToString());
                //Write action content
                strWriter.WriteLine(a.Content);
                //Write action end
                strWriter.WriteLine(doubleTabSpaces + UniEditorAbstract.ActionEndText);
            });
            //Write event end
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + UniEditorAbstract.EventEndText);
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + "}");
        }
    }
}
