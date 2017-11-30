using System.Collections;
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
    public int family;
    public int friends;
    static Player instance;

    //individaul flags for effects due to class roles
    public bool startDayLate;
    public bool TA;
    public bool Hidden;
    public bool Rich;
    public bool Otaku;
    public bool ROTC;
    public bool GOD;
    public List<Event> CurrentEvents;
    void Awake()
    {
        CurrentEvents = new List<Event>();
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
        tempList1.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 30, 3, "Test options3, things change", "You found a test event. Blame Jace if this continues"));
        tempList1.Add(new Options(4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 40, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        events1.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, 1, 1, tempList1, "This is the temp event. Blame Jace if this exists", 10, events1, "Test Event 1", false, false));
        events3.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, 1, 1, tempList1, "This is the temp event. Blame Jace if this exists", 10, events1, "Test Event 1", false, false));
        List<Options> tempList2 = new List<Options>();
        tempList2.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        tempList2.Add(new Options(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 20, 2, 2, 2, 2, 2, "Test options2, things change", "You found a test event. Blame Jace if this continues"));
        events2.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, 1, 1, tempList2, "This is the temp event. Blame Jace if this exists", 10, events2, "Test Event 2", false, false));
        events3.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, 1, 1, tempList2, "This is the temp event. Blame Jace if this exists", 10, events2, "Test Event 2", false, false));
        List<Options> tempList3 = new List<Options>();
        tempList3.Add(new Options(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 1, "Test options1, things change", "You found a test event. Blame Jace if this continues"));
        CurrentEvents.Add(new Event(10, 11, 12, 16.77f, 1, 1, 1, 1, 1, 1, 1, 1,tempList3, "This is the temp event. Blame Jace if this exists This also is a starting list", 10, events3, "Starting Event", false, false));
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
        stress = Mathf.Clamp(stress + amount,0,100);

        //write something to tell the HUD that our stress level needs to be updated


    }

    public void HomeworkMod(int amount)
    {
        //positive amount to increase homework, negative to decrease
        homework = Mathf.Clamp(homework + amount,0,200);

        //write something to tell the HUD that our homework level needs to be updated


    }

    public void ExhaustionMod(int amount)
    {
        //positive amount to increase exhaustion, negative to decrease
        exhaustion = Mathf.Clamp(exhaustion + amount,0,100);

        //write something to tell the HUD that our exhaustion level needs to be updated


    }

    public void MoneyMod(float amount)
    {
        //positive amount to increase homework, negative to decrease
        money = money + amount;

        //write something to tell the HUD that our money level needs to be updated


    }

    public void ChangeStr(int str)
    {
        strength = Mathf.Clamp(strength + str, 0, 100);
    }
    public void ChangeDex(int dex)
    {
        dexterity = Mathf.Clamp(dexterity + dex, 0, 100);
    }
    public void ChangeCon(int con)
    {
        constitution = Mathf.Clamp(constitution + con, 0, 100);
    }
    public void ChangeWis(int wis)
    {
        wisdom = Mathf.Clamp(wisdom + wis, 0, 100);
    }
    public void ChangeInt(int intel)
    {
        intelligence = Mathf.Clamp(intelligence + intel, 0, 100);
    }
    public void ChangeCha(int cha)
    {
        charisma = Mathf.Clamp(charisma + cha, 0, 100);
    }
    public void ChangeFam(int fam)
    {
        charisma = Mathf.Clamp(family + fam, 0, 100);
    }
    public void ChangeFri(int fri)
    {
        charisma = Mathf.Clamp(friends + fri, 0, 100);
    }
}
