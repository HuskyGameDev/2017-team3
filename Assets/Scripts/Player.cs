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
    protected int strength;
    protected int dexterity;
    protected int constitution;
    protected int wisdom;
    protected int intelligence;
    protected int charisma;


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
}
