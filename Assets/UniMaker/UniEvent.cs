using UniMaker.Actions;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace UniMaker.Events
{
    public class UniEvent
    {
        public EventTypes Type;
        public List<UniAction> Actions;
        public JSONObject Options;
        public string TextInList { get { return FormText(); } }
        public int Priority;

        public UniEvent(EventTypes type)
        {
            Type = type;
            Actions = new List<UniAction>();

            Options = new JSONObject();
            Options.AddField("type", Type.ToString());
        }

        public void SetArgs(List<string> args)
        {
            JSONObject argsArr = new JSONObject(JSONObject.Type.ARRAY);
            args.ForEach(a => argsArr.Add(a));
            Options.AddField("args", argsArr);
        }

        public void SetOptionsAndContent(string options, string content)
        {
            Options = new JSONObject(options);
            Type = (EventTypes)Enum.Parse(typeof(EventTypes), Options.GetField("type").str);

            Actions = new List<UniAction>();

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
                    UniAction newAction = UniAction.GetActionInstanceByType(actionOptionsJSON.GetField("type").str);
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
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + UniEditorAbstract.EventBeginText + "%" + Options.ToString());
            //Write method header
            if (Options.HasField("args"))
            {
                object[] args = Options.GetField("args").list.ConvertAll<object>(arg => arg.str).ToArray();
            }
            strWriter.WriteLine(UniEditorAbstract.TabSpaces + FormHeader());
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

        protected virtual string FormText() { return ""; }
        protected virtual string FormHeader() { return ""; }

        public static UniEvent GetEventInstanceByType(EventTypes type)
        {
            return (UniEvent)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Events.Event" + type.ToString()).Unwrap();
        }

        public static UniEvent GetEventInstanceByType(string type)
        {
            return (UniEvent)Activator.CreateInstance("Assembly-CSharp", "UniMaker.Events.Event" + type).Unwrap();
        }
    }
}
