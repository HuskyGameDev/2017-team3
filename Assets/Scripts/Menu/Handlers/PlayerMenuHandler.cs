﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMenuHandler : MonoBehaviour {
    public Text Selection;
    public InputField nameInput;
    public Text namefield;
    Clock clock;
    Player player;
    int chosenClass;
    public Text perks;
    // Use this for initialization
    void Start() { 
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        player.family = 50;
        player.friends = 50;
        XML_Load data = new XML_Load(ref (player.data));
    }
	
	// Update is called once per frame
	void Update () {
        //get the player's name from the inputfield and display it
        namefield.text = "Player name: \n"+nameInput.text;
	}
    /**
     * ChangeText(string input)
     * input: Info passed in by the button presses. This string will be told to the user and will eventually let the player class know what role the player chose
     **/
    public void ChoseClass(int input)
    {
        chosenClass = input;
        switch (input)
        {
            case 1://nobody
                perks.text = "Perks: None";
                break;
            case 2://student council
                if(!(player.data.student_Council))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Charisma, wisdom, and stress up. Start with more exhaustion and start days later ";
                break;
            case 3://athlete
                if (!(player.data.athlete))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Strength, Dexterity and Stress Up. Intelligence, Wisdom down and start with more exhaustion and start days later";
                break;
            case 4://pep/cheer
                if (!(player.data.cheer))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Charisma, friend relations up. Start with more exhaustion and start days later";
                break;
            case 5://nerd
                if (!(player.data.nerd))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Intelligence and wisdom up. Strength and Dexterity down";
                break;
            case 6://TA
                if (!(player.data.TA))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Double the money when you 'Do Job', Wisdom and Stress up.";
                break;
            case 7://Greek
                if (!(player.data.greek))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Friends and charisma up. Wisdom down.";
                break;
            case 8://try-hard
                if (!(player.data.tryHard))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Intelligence, wisdom, constitution, stress, and money up";
                break;
            case 9://Rich Kid
                if (!(player.data.rich_Kid))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Money way up! Friend relations, family relations up. If family relation drops too low: you will become a Nobody";
                break;
            case 10://Band Members
                if (!(player.data.band))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Charisma, wisdom, and stress up. Start with more exhaustion and start days later";
                break;
            case 11://MicroManaged
                if (!(player.data.microManaged))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Everything up and stress really high";
                break;
            case 12://Otaku
                if (!(player.data.otaku))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Low charisma skills and only get half of job money";
                break;
            case 13://ROTC
                if (!(player.data.ROTC))
                {
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Strength, dexterity, constitution, stress up. Personal respect";
                break;
            case 14://GOD
                if (!(player.data.GOD))
                {
                    if (nameInput.text == "Mitch Davis")
                    {
                        perks.text = "Perks: Max stats, everything reduces stress and everything increases money";
                        break;
                    }
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Max stats, everything reduces stress and everything increases money";
                break;
            case 15://Hidden
                if (!(player.data.hidden))
                {
                    if(nameInput.text == "420")
                    {
                        perks.text = "Perks: Minimum stats, no money, no stress, unable to do homework";
                        break;
                    }
                    perks.text = "Locked";
                    chosenClass = 1;
                    break;
                }
                perks.text = "Perks: Minimum stats, no money, no stress, unable to do homework";
                break;
        }
        Selection.text = "Chosen Class: " + chosenClass.ToString();
    }

    /**
    * Back ()
    * Destroys objects and returns to main menu
    **/
    public void back()
    {
        //since these don't destroy on their own, we need to destroy them when they aren't being used
        Destroy(player.gameObject);
        Destroy(clock.gameObject);
        SceneManager.LoadScene(0);
    }
    /**
    * StartGame ()
    * Loads the Day Menu Scene
    **/
    public void StartGame()
    {
        player.strength = 10;
        player.dexterity = 10;
        player.constitution = 10;
        player.intelligence = 10;
        player.charisma = 10;
        player.wisdom = 10;
        player.family = 10;
        player.friends = 10;
        player.stress = 10;
        player.money = (int)((Random.value * 200000)/100.0f);
        switch (chosenClass)
        {
            case 1:
                if (chosenClass == 1)
                {
                  
                }
                break;
            case 2:
                if (chosenClass == 2)
                {
                    player.charisma = 20;
                    player.wisdom = 20;
                    player.stress = 20;
                    player.startDayLate = true;
                }
                break;
            case 3:
                if (chosenClass == 3)
                {
                    player.strength = 20;
                    player.dexterity = 20;
                    player.intelligence = 5;
                    player.wisdom = 5;
                    player.stress = 20;
                    player.startDayLate = true;
                }
                break;
            case 4:
                if (chosenClass == 4)
                {
                    player.charisma = 20;
                    player.friends = 20;
                    player.startDayLate = true;
                }
                break;
            case 5:
                if (chosenClass == 5)
                {
                    player.intelligence = 20;
                    player.wisdom = 20;
                    player.strength = 5;
                    player.dexterity = 5; 
                }
                break;
            case 6:
                if (chosenClass == 6)
                {
                    player.wisdom = 20;
                    player.stress = 20;
                    player.TA = true;
                }
                break;
            case 7:
                if (chosenClass == 7)
                {
                    player.friends = 20;
                    player.charisma = 20;
                    player.wisdom = 5;
                }
                break;
            case 8:
                if (chosenClass == 8)
                {
                    player.intelligence = 20;
                    player.wisdom = 20;
                    player.constitution = 20;
                    player.stress = 20;
                    player.money = Random.value * 2000.0f + 350;
                }
                break;
            case 9:
                if (chosenClass == 9)
                {
                    player.friends = 20;
                    player.money = 9000;
                    player.Rich = true;
                }
                break;
            case 10:
                if (chosenClass == 10)
                {
                    player.charisma = 20;
                    player.wisdom = 20;
                    player.startDayLate = true;
                }
                break;
            case 11:
                if (chosenClass == 11)
                {
                    player.strength = 20;
                    player.dexterity = 20;
                    player.constitution = 20;
                    player.intelligence = 20;
                    player.charisma = 20;
                    player.wisdom = 20;
                    player.family = 20;
                    player.friends = 20;
                    player.stress = 30;
                    player.money = Random.value * 2000.0f + 350;
                }
                break;
            case 12:
                if (chosenClass == 12)
                {
                    player.charisma = 5;
                    player.Otaku=true;
                }
                break;
            case 13:
                if (chosenClass == 13)
                {
                    player.strength = 20;
                    player.dexterity = 20;
                    player.constitution = 20;
                    player.stress = 20;
                    player.ROTC = true;
                }
                break;
            case 14:
                if (chosenClass == 14)
                {
                    player.strength = 100;
                    player.dexterity = 100;
                    player.constitution = 100;
                    player.intelligence = 100;
                    player.charisma = 100;
                    player.wisdom = 100;
                    player.family = 100;
                    player.friends = 100;
                    player.stress = 0;
                    player.GOD = true;
                }
                break;
            case 15:
                if (chosenClass == 15)
                {
                    player.strength = 0;
                    player.dexterity = 0;
                    player.constitution = 0;
                    player.intelligence = 0;
                    player.charisma = 0;
                    player.wisdom = 0;
                    player.family = 0;
                    player.friends = 1;
                    player.stress = 0;
                    player.money = 0;
                    player.Hidden = true;
                }
                break;
        }
        //TODO add a endless flag and check it
        clock.endless = false;
        //get the player's name from the inputfield and store it in player
        player.PlayerName = nameInput.text;
        SceneManager.LoadScene(2);
    }
}
