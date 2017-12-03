using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

/**
 * A script that reads in events from game files and parses them into game objects. 
 */
public class Event_Parser{
        
    private const string endlessPath = @"Endless.event";
    private const string initialPath = @"Initial.event";
    private const string nextEventsPath = @"Next-Events\";
    private string dataFolder = Application.dataPath + @"\Data\"; //verify this is the correct path

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

    /**
     * x`
     */
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

    /**
     * 
     */
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

    /**
     * 
     */
    private Event BuildEvent(string line, StreamReader file)
    {
        //remove "e-{" and read name field
        line = line.Remove(0, 3);
        string name = line.Substring(0, line.IndexOf('{'));

        //remove "*}{" and read description field
        line = line.Remove(0, line.IndexOf('{') + 1);
        string description = line.Substring(0, line.IndexOf('{'));
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
        int str = Convert.ToInt32(line.Substring(0, line.IndexOf('d')));

        //dex threshold
        line = line.Remove(0, line.IndexOf('d') + 4);
        int dex = Convert.ToInt32(line.Substring(0, line.IndexOf('c')));

        //con threshold
        line = line.Remove(0, line.IndexOf('c') + 4);
        int con = Convert.ToInt32(line.Substring(0, line.IndexOf('i')));

        //int threshold
        line = line.Remove(0, line.IndexOf('i') + 4);
        int inte = Convert.ToInt32(line.Substring(0, line.IndexOf('w')));

        //wis threshold
        line = line.Remove(0, line.IndexOf('w') + 4);
        int wis = Convert.ToInt32(line.Substring(0, line.IndexOf('c')));

        //cha threshold
        line = line.Remove(0, line.IndexOf('c') + 4);
        int cha = Convert.ToInt32(line.Substring(0, line.IndexOf('w')));

        //weight modifier
        line = line.Remove(0, line.IndexOf('w') + 2);
        int w = Convert.ToInt32(line.Substring(0, line.IndexOf('f')));

        //family threshold
        line = line.Remove(0, line.IndexOf('f') + 4);
        int fam = Convert.ToInt32(line.Substring(0, line.IndexOf('f')));

        //friend threshold
        line = line.Remove(0, line.IndexOf('f') + 4);
        int friends = Convert.ToInt32(line.Substring(0, line.IndexOf('f')));

        //check for presence of options
        line = line.Remove(0, line.IndexOf('#') + 4);
        int optionCount = Convert.ToInt32(line);
        List<Options> options = new List<Options>(optionCount);

        for (int i = 0; i < optionCount; i++)
        {
            line = file.ReadLine();
            options.Add(BuildOption(line)); //read each option line by line
        }
        return new Event(s, h, e, m, str, dex, con, wis, inte, cha, fam, friends, options, description, w, new List<Event>(), name, false, false);
    }

    /**
     * 
     */
    private Options BuildOption(string line)
    {
        //remove "o-{" and read name field
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
        float m = Convert.ToSingle(line.Substring(0, line.IndexOf('s') - 1));

        //str change
        line = line.Remove(0, line.IndexOf('s') + 4);
        int dstr = Convert.ToInt32(line.Substring(0, line.IndexOf('d')));

        //dex change
        line = line.Remove(0, line.IndexOf('d') + 5);
        int ddex = Convert.ToInt32(line.Substring(0, line.IndexOf('c') - 1));

        //con change
        line = line.Remove(0, line.IndexOf('c') + 4);
        int dcon = Convert.ToInt32(line.Substring(0, line.IndexOf('w') - 1));

        //wis change
        line = line.Remove(0, line.IndexOf('w') + 4);
        int dwis = Convert.ToInt32(line.Substring(0, line.IndexOf('i') - 1));

        //int change
        line = line.Remove(0, line.IndexOf('i') + 4);
        int dinte = Convert.ToInt32(line.Substring(0, line.IndexOf('c') - 1));

        //cha change
        line = line.Remove(0, line.IndexOf('c') + 4);
        int dcha = Convert.ToInt32(line.Substring(0, line.IndexOf('f') - 1));

        //family change
        line = line.Remove(0, line.IndexOf('f') + 4);
        int dfam = Convert.ToInt32(line.Substring(0, line.IndexOf('f') - 1));

        //friend change
        line = line.Remove(0, line.IndexOf('c') + 4);
        int dfri = Convert.ToInt32(line.Substring(0, line.IndexOf('s') - 1));

        //stress change
        line = line.Remove(0, line.IndexOf('s') + 2);
        int ds = Convert.ToInt32(line.Substring(0, line.IndexOf('h') - 1));

        //homework change
        line = line.Remove(0, line.IndexOf('h') + 2);
        int dh = Convert.ToInt32(line.Substring(0, line.IndexOf('e') - 1));

        //exhaustion change
        line = line.Remove(0, line.IndexOf('e') + 2);
        int de = Convert.ToInt32(line.Substring(0, line.IndexOf('m') - 1));

        //money change
        line = line.Remove(0, line.IndexOf('m') + 2);
        float dm = Convert.ToSingle(line.Substring(0, line.IndexOf(';')));
        return new Options(s, h, e, m, dstr, ddex, dcon, dwis, dinte, dcha, dfam, dfri, ds, dh, de, dm, name, description);
    }

    /**
     * 
     */
    private string ReadString(string line)
    {
        int index = line.IndexOf('}');
        return line.Substring(0, index);
    }
}
