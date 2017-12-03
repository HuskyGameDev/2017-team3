using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRewards{
    private int x = 75;
    private int y = 25;
    public void unlock(Player P, Clock c,Unlocked results)
    {
        bool lowStr, highStr, lowDex, highDex, highCon, lowInt, highInt, lowWis, highWis, lowChar, highChar, lowStress, highStress, lowMoney, highMoney, absurdMoney, lowFam, highFam, highFri;
        lowStr = P.strength <= y;
        highStr = P.strength >= x;

        lowDex = P.dexterity <= y;
        highDex = P.dexterity >= x;

        highCon = P.constitution >= x;

        lowInt = P.intelligence <= y;
        highInt = P.intelligence >= x;

        lowWis = P.wisdom <= y;
        highWis = P.wisdom >= x;

        lowChar = P.charisma <= y;
        highChar = P.charisma >= x;

        lowStress = P.stress <= y;
        highStress = P.stress >= x;

        lowMoney = P.money < 25.0f;
        highMoney = P.money >= 75.0f;
        absurdMoney = P.money >= 9000.0f;

        lowFam = P.family <= y;
        highFam = P.family >= x;

        highFri = P.friends >= x;
        if (!P.data.endless && c.day > 75)
        {
            P.data.endless = true;
            results.endless = true;
        }

        if (!P.data.student_Council && P.eventUnlock1)
        {
            P.data.student_Council = true;
            results.student_Council = true;
        }

        if (!P.data.athlete && highStr && highDex && highCon)
        {
            P.data.athlete = true;
            results.athlete = true;
        }
        if (!P.data.cheer && highDex && highCon && highChar)
        {
            P.data.cheer = true;
            results.cheer = true;
        }
        if (!P.data.band && highWis && highChar)
        {
            P.data.band = true;
            results.band = true;
        }
        if (!P.data.nerd && highInt && highWis)
        {
            P.data.nerd = true;
            results.nerd = true;
        }

        if (!P.data.TA && P.eventUnlock2)
        {
            P.data.TA = true;
            results.TA = true;
        }
        if (!P.data.greek && P.eventUnlock3)
        {
            P.data.greek = true;
            results.greek = true;
        }
        if(!P.data.hidden && P.name.Equals("upupdowndownleftrightleftrightba", System.StringComparison.InvariantCultureIgnoreCase))
        {
            P.data.hidden = true;
            results.hidden = true;
        }
        if (!P.data.tryHard && highStr && highDex && highInt && highWis && highChar && highStress)
        {
            P.data.tryHard = true;
            results.tryHard = true;
        }
        if (!P.data.rich_Kid && absurdMoney)
        {
            P.data.rich_Kid = true;
            results.rich_Kid = true;
        }
        if (!P.data.microManaged && highStress && highFam)
        {
            P.data.microManaged = true;
            results.microManaged = true;
        }
        if (!P.data.otaku && lowStr && lowDex && highCon && lowInt && lowWis && lowChar && lowMoney && lowFam && highFri)
        {
            P.data.otaku = true;
            results.otaku = true;
        }
        if (!P.data.ROTC && highStr && highDex && highCon && highStress)
        {
            P.data.ROTC = true;
            results.ROTC = true;
        }
        if (!P.data.GOD && highStr && highDex && highCon && highInt && highWis && highChar && lowStress && highMoney && highFam && highFri)
        {
            P.data.GOD = true;
            results.GOD = true;
        }
    }
}
