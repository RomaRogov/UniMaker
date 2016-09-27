using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using UniMaker.Events;

namespace UniMaker
{
    public class UniVariable
    {
        public string VarAccessModifier;
        public string VarType;
        public string VarName;
        public string VarValue;

        public UniVariable(string options)
        {
            JSONObject optionsJSON = new JSONObject(options);
            VarAccessModifier = optionsJSON.GetField("acceessModifier").str;
            VarType = optionsJSON.GetField("type").str;
            VarName = optionsJSON.GetField("name").str;
            VarValue = optionsJSON.GetField("value").str;
        }
    }

    public class UniEditorAbstract
    {
        public const string TabSpaces = "    ";
        public const string UsingsText = "//USINGS";
        public const string ClassBeginText = "//CLASS";
        public const string ClassEndText = "//ENDCLASS";
        public const string VarText = "//VAR";
        public const string EventBeginText = "//EVENT";
        public const string EventEndText = "//ENDEVENT";
        public const string ActionBeginText = "//ACTION";
        public const string ActionEndText = "//ENDACTION";

        public string FileName;
        public List<string> Usings;
        public string ClassName;
        public List<UniVariable> Variables;
        public List<UniEvent> Events;
        public bool ParseFailed;

        public int EventCount { get { return Events.Count; } }

        private enum ParsingMode { USINGS, CLASS, ENDCLASS, VAR, EVENT, ENDEVENT };

        public UniEditorAbstract(string fileName)
        {
            FileName = fileName;
            Usings = new List<string>();
            Variables = new List<UniVariable>();
            Events = new List<UniEvent>();
        }

        public UniEditorAbstract(string behaviourCode, string fileName)
        {
            FileName = fileName;
            Usings = new List<string>();
            Variables = new List<UniVariable>();
            Events = new List<UniEvent>();

            StringReader strReader = new StringReader(behaviourCode);
            string currentLine = null;
            string eventContent = "";
            string eventOptions = null;
            ParsingMode mode = ParsingMode.USINGS;
            ParseFailed = true;

            while ((currentLine = strReader.ReadLine()) != null)
            {
                currentLine = currentLine.TrimStart(new char[] { ' ', '\t' });

                if (currentLine.StartsWith(UsingsText)) { mode = ParsingMode.USINGS; continue; }
                if (currentLine.StartsWith(ClassBeginText)) { mode = ParsingMode.CLASS; continue; }
                if (currentLine.StartsWith(ClassEndText)) { mode = ParsingMode.ENDCLASS; continue; }
                if (currentLine.StartsWith(VarText))
                {
                    mode = ParsingMode.VAR;
                    Variables.Add(new UniVariable(currentLine.Substring(currentLine.IndexOf('%') + 1)));
                    continue;
                }
                if (currentLine.StartsWith(EventBeginText))
                {
                    mode = ParsingMode.EVENT;
                    eventOptions = currentLine.Substring(currentLine.IndexOf('%') + 1);
                    continue;
                }
                if (currentLine.StartsWith(EventEndText)) { mode = ParsingMode.ENDEVENT; continue; }

                switch (mode)
                {
                    case ParsingMode.USINGS:
                        Usings.Add(currentLine);
                        break;
                    case ParsingMode.CLASS:
                        string[] classParts = currentLine.Split(' '); //0 - modifier, 1 - "class", 2 - name, 3 - ":", 4 - baseName, 5 - "{"
                        if (classParts[4] == "UniBehaviour") { ParseFailed = false; }
                        ClassName = classParts[2];
                        break;
                    case ParsingMode.EVENT:
                        eventContent += currentLine + "\n";
                        break;
                    case ParsingMode.ENDEVENT:
                        JSONObject eventOptionsJSON = new JSONObject(eventOptions);
                        UniEvent newEvent = UniEvent.GetEventInstanceByType(eventOptionsJSON.GetField("type").str);
                        newEvent.SetOptionsAndContent(eventOptions, eventContent);
                        Events.Add(newEvent);
                        eventContent = "";
                        break;
                }
            }
            strReader.Close();
        }

        public string CombineScript(StreamWriter strWriter)
        {
            //Write all usings
            strWriter.WriteLine(UsingsText);
            Usings.ForEach(u => strWriter.WriteLine(u));
            //Write class header
            strWriter.WriteLine(ClassBeginText);
            strWriter.WriteLine("public class " + ClassName + " : UniBehaviour {");
            //Write variables
            Variables.ForEach(v =>
            {
                //Write var data
                strWriter.WriteLine(TabSpaces + VarText + "%" +
                    "{\"acceessModifier\":\"" + v.VarAccessModifier + "\"," +
                    "\"type\":\"" + v.VarType + "\"," +
                    "\"name\":\"" + v.VarName + "\"," +
                    "\"value\":\"" + v.VarValue + "\"}");
                //Write var code
                strWriter.WriteLine(TabSpaces + v.VarAccessModifier + " " + v.VarType + " " + v.VarName + " = " + v.VarValue + ";");
            });
            //Write events (they forming string with line end by themselves)
            Events.ForEach(e => { e.CombineScript(strWriter); });
            //Write class end
            strWriter.WriteLine(ClassEndText);
            strWriter.WriteLine("}");

            string result = strWriter.ToString();
            strWriter.Close();

            return result;
        }
    }
}
