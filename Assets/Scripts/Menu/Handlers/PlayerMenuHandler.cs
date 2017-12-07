using System.Collections;
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
    void Start () {
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        player.family = 50;
        player.friends = 50;
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
        Selection.text = "Chosen Class: " +input.ToString();
        chosenClass = input;
        switch (chosenClass)
        {
            case 1:
                if (chosenClass == 1)
                {
                    perks.text = "Perks: None";
                }
                break;
            case 2:
                if(chosenClass == 2)
                {
                    perks.text = "Perks: Charisma, wisdom, and stress up. Start with more exhaustion and start days later ";
                }
                break;
            case 3:
                if(chosenClass == 3)
                {
                    perks.text = "Perks: Strength, Dexterity and Stress Up. Intelligence, Wisdom down and start with more exhaustion and start days later";
                }
                break;
            case 4:
                if(chosenClass == 4)
                {
                    perks.text = "Perks: Charisma, friend relations up. Start with more exhaustion and start days later";
                }
                break;
            case 5:
                if(chosenClass == 5)
                {
                    perks.text = "Perks: Intelligence and wisdom up. Strength and Dexterity down";
                }
                break;
            case 6:
                if (chosenClass == 6)
                {
                    perks.text = "Perks: Double the money when you 'Do Job', Wisdom and Stress up.";
                }
                break;
            case 7:
                if (chosenClass == 7)
                {
                    perks.text = "Perks: Friends and charisma up. Wisdom down.";
                }
                break;
            case 8:
                if (chosenClass == 8)
                {
                    perks.text = "Perks: Intelligence, wisdom, constitution, stress, and money up";
                }
                break;
            case 9:
                if (chosenClass == 9)
                {
                    perks.text = "Perks: Money way up! Friend relations, family relations up. If family relation drops too low: you will become a Nobody";
                }
                break;
            case 10:
                if (chosenClass == 10)
                {
                    perks.text = "Perks: Charisma, wisdom, and stress up. Start with more exhaustion and start days later";
                }
                break;
            case 11:
                if (chosenClass == 11)
                {
                    perks.text = "Perks: Everything up and stress really high";
                }
                break;
            case 12:
                if (chosenClass == 12)
                {
                    perks.text = "Perks: Low charisma skills and only get half of job money";
                }
                break;
            case 13:
                if (chosenClass == 13)
                {
                    perks.text = "Perks: Strength, dexterity, constitution, stress up. Personal respect";
                }
                break;
            case 14:
                if (chosenClass == 14)
                {
                    perks.text = "Perks: Max stats, everything reduces stress and everything increases money";
                }
                break;
            case 15:
                if (chosenClass == 15)
                {
                    perks.text = "Perks: Minimum stats, no money, no stress, unable to do homework";
                }
                break;
        }
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
        //get the player's name from the inputfield and store it in player
        player.PlayerName = nameInput.text;
        SceneManager.LoadScene(2);
    }
}
