﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class Event_Parser{

    private const string endlessPath = @"Endless.event";
    private const string initialPath = @"Initial.event";
    private const string nextEventsPath = @"Next-Events\";
    private string dataFolder = Application.dataPath + @"Data\"; //verify this is the correct path

    private List<Event> events;

    public List<Event> GetEvents() { return events; }

    public Event_Parser(bool endless)
    {
        events = ParseFile(dataFolder + initialPath);
        if(endless)
        {
            events.AddRange(ParseFile(dataFolder + endlessPath));
        }
    }

    private List<Event> ParseFile(string path)
    {
        List<Event> events = new List<Event>();
        StreamReader file = new StreamReader(path);
        string line;
        Event e;
        while((line = file.ReadLine()) != null)
        {
            if (line.StartsWith("e-"))
            {
                List<Event> following = new List<Event>();
                if(line.Contains("#ne:"))
                {
                    following = BuildNextEvents(file.ReadLine());
                    line = line.Remove(line.LastIndexOf('#'));
                }
                e = BuildEvent(line, file);
                e.setNextEvents(following);
                events.Add(e);
            }
        }
        return events;
    }

    private List<Event> BuildNextEvents(string line)
    {
        string path;
        List<Event> nextEvents = new List<Event>();
        line.Remove(0, 3);

        while (line.Contains("#filename:"))
        {
            line = line.Remove(0, line.IndexOf(':') + 1);
            path = dataFolder + nextEventsPath +
                (line.Contains("#filename:") ? line.Substring(0, line.IndexOf('#')) : line.Trim());
            nextEvents.AddRange(ParseFile(path));
        }
        return nextEvents;
    }

    private Event BuildEvent(string line, StreamReader file)
    {
        //remove "e-{" and read name field
        line = line.Remove(0, 3);
        string name = ReadString(line);
        //remove "*}{" and read description field
        line = line.Remove(0, line.IndexOf('{') + 1);
        string description = ReadString(line);
        //cut off the description, begin reading ints and such, oh boy

        //stress threshold
        line = line.Remove(0, line.IndexOf('}') + 4);
        int s = Convert.ToInt32(line.Substring(0, line.IndexOf('h')));

        //homework threshold
        line = line.Remove(0, line.IndexOf('h') + 2);
        int h = Convert.ToInt32(line.Substring(0, line.IndexOf('e')));

        //exhaustiion threshold
        line = line.Remove(0, line.IndexOf('e') + 2);
        int e = Convert.ToInt32(line.Substring(0, line.IndexOf('m')));

        //money threshold
        line = line.Remove(0, line.IndexOf('m') + 2);
        float m = Convert.ToSingle(line.Substring(0, line.IndexOf('s')));

        //str threshold
        line = line.Remove(0, line.IndexOf('s') + 4);
        uint str = Convert.ToUInt32(line.Substring(0, line.IndexOf('d')));

        //dex threshold
        line = line.Remove(0, line.IndexOf('d') + 4);
        uint dex = Convert.ToUInt32(line.Substring(0, line.IndexOf('c')));

        //con threshold
        line = line.Remove(0, line.IndexOf('c') + 4);
        uint con = Convert.ToUInt32(line.Substring(0, line.IndexOf('i')));

        //int threshold
        line = line.Remove(0, line.IndexOf('i') + 4);
        uint inte = Convert.ToUInt32(line.Substring(0, line.IndexOf('w')));

        //wis threshold
        line = line.Remove(0, line.IndexOf('w') + 4);
        uint wis = Convert.ToUInt32(line.Substring(0, line.IndexOf('c')));

        //cha threshold
        line = line.Remove(0, line.IndexOf('c') + 4);
        uint cha = Convert.ToUInt32(line.Substring(0, line.IndexOf('w')));

        //weight modifier
        line = line.Remove(0, line.IndexOf('w') + 2);
        int w = Convert.ToInt32(line.Substring(0, line.IndexOf('#')));

        //check for presence of options
        line = line.Remove(0, line.IndexOf('#') + 4);
        int optionCount = Convert.ToInt32(line);
        List<Options> options = new List<Options>(optionCount);

        for(int i = 0; i < optionCount; i++, line = file.ReadLine())
            options.Add(BuildOption(line)); //read each option line by line

        return new Event(s, h, e, m, str, dex, con, wis, inte, cha, new List<Options>(), description, w, new List<Event>(), name, false, false);
    }

    private Options BuildOption(string line)
    {
        return null; //TODO
    }

    private string ReadString(string line)
    {
        return line.Substring(0, line.IndexOf('}'));
    }
}
