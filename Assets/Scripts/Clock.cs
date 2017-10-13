using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    protected uint day;
    protected uint time;
    protected uint startDay = 6;

	// Use this for initialization
	void Start () {
        day = 1;
        time = startDay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeHour(uint hours)
    {
        uint temp = time + hours;
        if (temp >= 24)
        {
            //if the number of hours added puts us over 24, we need to start a new day
            this.ChangeDay(temp / 24, temp % 24);
        }
        else
        {
            time = temp % 24;
        }
    }

    void ChangeDay(uint amount, uint newtime)
    {
        day = day + amount; //increases the day number by the amount of days we want
        if(newtime != 0)
        {
            //if we want to set what time the new day starts, it can be set here
            time = newtime;
        }
    }

    void IncrementDay ()
    {
        //if all we need to do is increase the day by one, then we should use this
        day = day++;
        time = startDay;
    }
}
