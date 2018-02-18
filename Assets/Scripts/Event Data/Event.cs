using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event {
    int stress; //if player stress is larger than this value
    int homework;    //if player homework is larger than this value
    int exhaustion;  //if player exhaustion  is larger than this value
    float money; //if player money is larger than this value
    int strength;
    int dexterity;
    int constitution;
    int wisdom;
    int intelligence;
    int charisma;
    int family;
    int friends;
    List<Options> Choices;
    string eventDescription;
    string eventName;
    int weight;
    List<Event> nextEvents;
    public bool repeatable;
    bool start;
    bool endless;

    public Event(int s, int h, int e, float m, int str, int dex, int con, int wis, int it, int cha,int fam, int fri, List<Options> c, string desc, int w, List<Event> n, string name, bool repeatable, bool start, bool endless)
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
        nextEvents = n;
        eventName = name;
        this.start = start;
        this.endless = endless;
        family = fam;
        friends = fri;
    }

    public string getDescription()
    {
        return eventDescription;
    }

    public string getName()
    {
        return eventName;
    }

    public int getWeight(Player p)
    {

        //bool s = (p.stress < stress)||(stress<=0);
        bool s = translate(p.stress, stress);

        //bool h = (p.homework < homework)||(homework<=0);
        bool h = translate(p.homework, homework);

        //bool e = (p.exhaustion < exhaustion)||(exhaustion<=0);
        bool e = translate(p.exhaustion, exhaustion);

        //bool m = p.money < money;
        bool m = translateF(p.money, money);

        //bool str = p.strength > strength;
        bool str = translate(p.strength, strength);

        //bool dex = p.dexterity > dexterity;
        bool dex = translate(p.dexterity, dexterity);

        //bool con = p.constitution > constitution;
        bool con = translate(p.constitution, constitution);

        //bool wis = p.wisdom > wisdom;
        bool wis = translate(p.wisdom, wisdom);

        //bool it = p.intelligence > intelligence;
        bool it = translate(p.intelligence, intelligence);

        //bool cha = p.charisma > charisma;
        bool cha = translate(p.charisma, charisma);

        if (s && h && e && m && str && dex && con && wis && it && cha)
        {
            return weight * 2;
        }
        return weight;
    }

    bool translate( int playerValue , int threshold)
    {
        //if threshold is negative, we want to see if the player's stat is below the absolute value of that stat
        if( threshold < 0)
        {
            if( playerValue < Mathf.Abs(threshold))
            {
                return true;
            }
           
        }
        //otherwise, check if player stat is above that value
        else if (threshold > 0)
        {
            if (playerValue > threshold)
            {
                return true;
            }
        }
        else if(threshold == 0)
        {
            return true;
        }
        //else, return false;
        return false;
    }

    //this is the same thing as above, but for float values
    bool translateF(float playerValue, float threshold)
    {
        //if threshold is negative, we want to see if the player's stat is below the absolute value of that stat
        if (threshold < 0)
        {
            if (playerValue < Mathf.Abs(threshold))
            {
                return true;
            }

        }
        //otherwise, check if player stat is above that value
        else if (threshold > 0)
        {
            if (playerValue > threshold)
            {
                return true;
            }
        }
        else if (threshold <= 0)
        {
            return true;
        }
        //else, return false;
        return false;
    }

    public List<Options> eventChosen()
    {
        return Choices;
    }

    public List<Event> getNextEvents()
    {
        return nextEvents;
    }

    public void setNextEvents(List<Event> list)
    {
        this.nextEvents = list;
    }
}
