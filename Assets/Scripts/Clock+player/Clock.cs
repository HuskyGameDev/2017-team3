using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    public int day;
    public int time;
    protected int startDay = 6; // starting at 6 am if the player didn't go to class
    protected int startDayWClass = 16; // starting at 4 pm if the player did go to calss, can be adjusted
    protected int startDayWAct = 18;
    public bool endless;
    static Clock instance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null || GameObject.FindGameObjectWithTag("Clock") == null)
        {
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        day = 1;
        time = startDay;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHour(int hours)
    {
        int temp = time + hours;
        if (temp >= 24)
        {
            //if the number of hours added puts us over 24, we need to start a new day
            day++;
            time = temp % 24;
        }
        else
        {
            time = temp % 24;
        }
    }

    public void ChangeDay(int amount, int newtime)
    {
        day = day + amount; //increases the day number by the amount of days we want
        if(newtime != 0)
        {
            //if we want to set what time the new day starts, it can be set here
            time = newtime;
        }
    }
    public void IncrementDay (bool Went, bool act)
    {
        //if all we need to do is increase the day by one, then we should use this
        if (act)
        {
            time = startDayWAct;
        }
        if (Went)//if the student went to class
        {
            //start day at 4 pm
            time = startDayWClass;
        }
        else
        {
            //start day at 6 am
            time = startDay;
        }
        day++;
        
    }
}
