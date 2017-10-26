using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {
    int stress; //if player stress is larger than this value
    int homework;    //if player homework is larger than this value
    int exhaustion;  //if player exhaustion  is larger than this value
    float money; //if player money is larger than this value
    uint strength;
    uint dexterity;
    uint constitution;
    uint wisdom;
    uint intelligence;
    uint charisma;
    List<Options> Choices;
    string eventDescription;
    int weight;
    List<Event> nextEvents;

    public Event(int s, int h, int e, float m, uint str, uint dex, uint con, uint wis, uint it, uint cha, List<Options> c, string desc, int w)
    {
        stress = s;
        homework = h;
        exhaustion = e;
        money = m;
        strength = str;
        dexterity = dex;
        constitution = con;
        wisdom = wis;
        intelligence = it;
        charisma = cha;
        Choices = c;
        eventDescription = desc;
        weight = w;
    }

    public string getDescription()
    {
        return eventDescription;
    }

    public int getWeight(Player p)
    {
        bool s = p.stress < stress;
        bool h = p.homework < homework;
        bool e = p.exhaustion < exhaustion;
        bool m = p.money < money;
        bool str = p.strength < strength;
        bool dex = p.dexterity < dexterity;
        bool con = p.constitution < constitution;
        bool wis = p.wisdom < wisdom;
        bool it = p.intelligence < intelligence;
        bool cha = p.charisma < charisma;
        if (s && h && e && m && str && dex && con && wis && it && cha)
        {
            return weight * 2;
        }
        return weight;
    }
    public List<Options> eventChosen()
    {
        return Choices;
    }
}
