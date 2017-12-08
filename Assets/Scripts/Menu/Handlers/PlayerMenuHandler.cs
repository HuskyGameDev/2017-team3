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
    // Use this for initialization
    void Start () {
        XML_Load data = new XML_Load(ref (player.data));
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
        //TODO add a endless flag and check it
        clock.endless = false;
        //get the player's name from the inputfield and store it in player
        player.PlayerName = nameInput.text;
        SceneManager.LoadScene(2);
    }
}
