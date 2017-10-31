﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    //stats
    public int stress;
    public int homework;
    public int exhaustion;
    public float money;
    public bool wentToClass;
    public string PlayerName;

    //attributes
    public int strength;
    public int dexterity;
    public int constitution;
    public int wisdom;
    public int intelligence;
    public int charisma;
    static Player instance;

    public List<Event> CurrentEvents;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null || GameObject.FindGameObjectWithTag("PlayerStats") == null)
        {
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
        List<Event> events1 = new List<Event>();
        List<Event> events2 = new List<Event>();
        List<Event> events3 = new List<Event>();
        List<Options> tempList1 = new List<Options>();
        tempList1.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 2, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 30, 3, 3, 3, "Test options3, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 40, 4, 4, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        events1.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, tempList1, "This is the temp event. Blame Jace if this exists", 10, events1, "Test Event 1"));
        events3.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, tempList1, "This is the temp event. Blame Jace if this exists", 10, events1, "Test Event 1"));
        List<Options> tempList2 = new List<Options>();
        tempList2.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        tempList2.Add(new Options(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 2, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        events2.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, tempList2, "This is the temp event. Blame Jace if this exists", 10, events2, "Test Event 2"));
        events3.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, tempList2, "This is the temp event. Blame Jace if this exists", 10, events2, "Test Event 2"));
        List<Options> tempList3 = new List<Options>();
        tempList1.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        CurrentEvents.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, tempList1, "This is the temp event. Blame Jace if this exists This also is a starting list", 10, events3, "Starting Event"));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        //if the character's stats result in death, do that stuff here
    }

   public  void StressMod(int amount)
    {
        //positive amount to increase stress, negative to decrease
        stress = stress + amount;

        //write something to tell the HUD that our stress level needs to be updated


    }

    public void HomeworkMod(int amount)
    {
        //positive amount to increase homework, negative to decrease
        homework = homework + amount;

        //write something to tell the HUD that our homework level needs to be updated


    }

    public void ExhaustionMod(int amount)
    {
        //positive amount to increase exhaustion, negative to decrease
        exhaustion = exhaustion + amount;

        //write something to tell the HUD that our exhaustion level needs to be updated


    }

    public void MoneyMod(int amount)
    {
        //positive amount to increase homework, negative to decrease
        money = money + amount;

        //write something to tell the HUD that our money level needs to be updated


    }
}
