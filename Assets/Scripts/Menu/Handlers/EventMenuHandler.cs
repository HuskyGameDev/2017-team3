using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventMenuHandler : MonoBehaviour {
    bool showWindow = false;
    public Popup popupmenu;
    public Button choice1;
    public Button choice2;
    public Button choice3;
    public Button choice4;
    public Text eventDescription;
    public Text choiceDescription;
    Clock clock;
    Player player;
    // Use this for initialization
    void Start () {
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void popup()
    {   
        //toggle the popup window
        if (showWindow)
        {
            showWindow = false;
        }
        else
        {
            showWindow = true;
        }
        popupmenu.toggleActive(showWindow);
    }
    public void back()
    {
        //since these don't destroy on their own, we need to destroy them when they aren't being used
        Destroy(player);
        Destroy(clock);
        SceneManager.LoadScene(0);
    }
    public void NextDay()
    {
        clock.IncrementDay(player.wentToClass);
        SceneManager.LoadScene(2);
    }

}
