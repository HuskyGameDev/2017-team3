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
    /**isAvailable(Player p)
     * p: reference to a player
     * States which option is avaiable
     **/
    public bool isAvailable(Player p)
    {
        bool s = p.stress < stress && stress!=0;
        bool h = p.homework < homework && homework!=0;
        bool e = p.exhaustion < exhaustion && exhaustion!=0;
        bool m = p.money > money && money!=0;
        return s  && h && e && m;
    }
    /**updatePlayer(Player p)
     * 
     **/
    public void updatePlayer(Player p)
    {
        p.ExhaustionMod(addexhaustion);
        p.HomeworkMod(addhomework);
        p.MoneyMod(addmoney);
        p.StressMod(addstress);
    }
    public bool[] missing (Player p)
    {
        bool[] results = new bool[4];
        results[0] = !(p.stress < stress && stress != 0);
        results[1] = !(p.homework < homework && homework != 0);
        results[2] = !(p.exhaustion < exhaustion && exhaustion != 0);
        results[3] = !(p.money > money && money != 0);
        return results;
    }
}
