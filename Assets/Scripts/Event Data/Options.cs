using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options {
    public int stress;      //player needs less than this level of stress
    public int homework;    //player needs less than this level of homework
    public int exhaustion;  //player needs less than this level of exhaustion, which should be 100 - addexhaustion
    public float money;     //player needs at least this amount of money
    public string text;
    public string name;

    protected int addstrength;
    protected int adddexterity;
    protected int addconstitution;
    protected int addwisdom;
    protected int addintelligence;
    protected int addcharisma;
    public int addstress;
    public int addhomework;
    public int addexhaustion;
    public float addmoney;
    public Options(int s, int h, int e, float m, int str, int dex, int con, int wis, int it, int cha, int adds, int addh, int adde, float addm, string t, string n)
    {
        stress = s;
        homework = h;
        exhaustion = e;
        money = m;
        text = t;
        name = n;
        addstrength = str;
        adddexterity = dex;
        addconstitution = con;
        addwisdom = wis;
        addintelligence = it;
        addcharisma = cha;
        addstress = adds;
        addhomework = addh;
        addexhaustion = adde;
        addmoney = addm;
    }
    public bool isAvailable(Player p)
    {
        bool s = p.stress < stress;
        bool h = p.homework < homework;
        bool e = p.exhaustion < exhaustion;
        bool m = p.money > money;
        return s  && h && e && m;
    }
    public void updatePlayer(Player p)
    {

    }
}
