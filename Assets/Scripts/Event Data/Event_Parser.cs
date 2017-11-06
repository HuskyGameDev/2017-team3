using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Event_Parser{
    private List<Event> events = new List<Event>();

    public List<Event> getEvents() { return events; }

    public Event_Parser(bool endless)
    {

    }

    private void parseFile(string path)
    {
        StreamReader file = new StreamReader(path);
        string line;
        Event e;
        while((line = file.ReadLine()) != null)
        {
            if (line.StartsWith("e-"))
            {
               e = buildEvent(line);
            }
        }
    }

    private Event buildEvent(string line)
    {
        Event e;
        //remove "e-{" and read name field
        line.Remove(0, 3);
        string name = readString(line);
        //remove "*}{" and read description field
        line.Remove(0, line.IndexOf('{') + 1);
        string description = readString(line);


        return null;
    }

    private string readString(string line)
    {
        return line.Substring(0, line.IndexOf('}'));
    }

    private Options buildOption(string line)
    {
        return null; 
    }
}
