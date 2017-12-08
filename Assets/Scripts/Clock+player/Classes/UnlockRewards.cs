using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRewards{
    private int x = 75; //our designated high value;
    private int y = 25; //our desiganted low value
    /**
     * parameters:
     * P= the player
     * c= clock
     * results = return values to let menu know what was unlocked
     */
    public void unlock(Player P, Clock c,Unlocked results)
    {
        bool lowStr, highStr, lowDex, highDex, highCon, lowInt, highInt, lowWis, highWis, lowChar, highChar, lowStress, highStress, lowMoney, highMoney, absurdMoney, lowFam, highFam, highFri;
        lowStr = P.strength <= y; //does the player have low strength
        highStr = P.strength >= x; //does the player have high strength

        lowDex = P.dexterity <= y; //does the player have low dexterity
        highDex = P.dexterity >= x; //does the player have high dexterity

        highCon = P.constitution >= x; //does the player have high constitution

        lowInt = P.intelligence <= y; //does the player have low intelligence
        highInt = P.intelligence >= x; //does the playet have high intelligence

        lowWis = P.wisdom <= y; //does the player have low wisdom
        highWis = P.wisdom >= x; //does the player have high wisdom

        lowChar = P.charisma <= y; //does the player have low charisma
        highChar = P.charisma >= x; //does the player have high charisma

        lowStress = P.stress <= y; //does the player have low stress
        highStress = P.stress >= x; //does the player have high stress

        lowMoney = P.money < 25.0f; //does the player have low money
        highMoney = P.money >= 75.0f; //does the player have high money
        absurdMoney = P.money >= 9000.0f; //does the player have an excessive amount of money

        lowFam = P.family <= y; //does the player have a bad relationship with family
        highFam = P.family >= x; //does the player have a good relationship with family

        highFri = P.friends >= x; //does the player have good relationship with friends


        /**
         * Go through pre defined vallues for whether or not a class is unlcoked.
         * We can't use just 1 because it would easily say what was and was not unlocked
         */
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
        if(!P.data.hidden && P.PlayerName.Equals("upupdowndownleftrightleftrightba", System.StringComparison.InvariantCultureIgnoreCase))
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
