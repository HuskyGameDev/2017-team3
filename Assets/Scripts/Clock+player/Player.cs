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
    static Player instance;
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
