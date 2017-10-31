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
    Event todaysEvent;
    // Use this for initialization
    void Start () {
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        EventSelector selector = new EventSelector();
        todaysEvent = selector.getEvent(player);
        choice2.gameObject.SetActive(false);
        choice3.gameObject.SetActive(false);
        choice4.gameObject.SetActive(false);
        if (todaysEvent.Equals(null))
        {
            choice1.GetComponentInChildren<Text>().text = "Error, Default choice only";
            eventDescription.text = "Error, Default event";
        }
        else
        {
            eventDescription.text = todaysEvent.getDescription();
            List<Options> eventOptions = todaysEvent.eventChosen();
            switch (eventOptions.Count)
            {
                case 4:
                    choice4.GetComponentInChildren<Text>().text = eventOptions[4].name;
                    choice4.gameObject.SetActive(true);
                    goto case 3;
                case 3:
                    choice3.GetComponentInChildren<Text>().text = eventOptions[3].name;
                    choice3.gameObject.SetActive(true);
                    goto case 2;
                case 2:
                    choice2.GetComponentInChildren<Text>().text = eventOptions[2].name;
                    choice2.gameObject.SetActive(true);
                    goto case 1;
                case 1:
                    choice1.GetComponentInChildren<Text>().text = eventOptions[1].name;
                    break;
                default:
                    choice1.GetComponentInChildren<Text>().text = "ERROR!";
                    break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void popup(int i)
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
        if (todaysEvent.Equals(null))
        {
            choiceDescription.text = "ERROR! Default Value";
        }
        else
        {
            List<Options> eventOptions = todaysEvent.eventChosen();
            switch (i)
            {
                case 4:
                    choiceDescription.text = eventOptions[4].text;
                    eventOptions[4].updatePlayer(player);
                    break;
                case 3:
                    choiceDescription.text = eventOptions[3].text;
                    break;
                case 2:
                    choiceDescription.text = eventOptions[2].text;
                    break;
                case 1:
                    choiceDescription.text = eventOptions[1].text;
                    break;
                default:
                    choiceDescription.text = "ERROR!";
                    break;
            }
        }
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
