using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //stats
    public int stress;
    public int homework;
    public int exhaustion;
    public float money;


    //attributes
    protected uint strength;
    protected uint dexterity;
    protected uint constitution;
    protected uint wisdom;
    protected uint intelligence;
    protected uint charisma;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Die()
    {
        //if the character's stats result in death, do that stuff here
    }

    void StressMod(int amount)
    {
        //positive amount to increase stress, negative to decrease
        stress = stress + amount;

        //write something to tell the HUD that our stress level needs to be updated


    }

    void HomeworkMod(int amount)
    {
        //positive amount to increase homework, negative to decrease
        homework = homework + amount;

        //write something to tell the HUD that our homework level needs to be updated


    }

    void ExhaustionMod(int amount)
    {
        //positive amount to increase exhaustion, negative to decrease
        exhaustion = exhaustion + amount;

        //write something to tell the HUD that our exhaustion level needs to be updated


    }

    void MoneyMod(int amount)
    {
        //positive amount to increase homework, negative to decrease
        money = money + amount;

        //write something to tell the HUD that our money level needs to be updated


    }
}
