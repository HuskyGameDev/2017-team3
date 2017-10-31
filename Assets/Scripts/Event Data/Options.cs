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

    protected uint addstrength;
    protected uint adddexterity;
    protected uint addconstitution;
    protected uint addwisdom;
    protected uint addintelligence;
    protected uint addcharisma;
    public int addstress;
    public int addhomework;
    public int addexhaustion;
    public float addmoney;
    public Options(int s, int h, int e, float m, string t, string n, uint str, uint dex, uint con, uint wis, uint it, uint cha, int adds, int addh, int adde, float addm){
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
