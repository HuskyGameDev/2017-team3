using System.Collections;
using System.Collections.Generic;
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
    public Text eventName;
    Clock clock;
    Player player;
    Event todaysEvent;
    // Use this for initialization
    void Start () {
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        //generate this event
        EventSelector selector = new EventSelector();
        todaysEvent = selector.getEvent(player);
        //disable and make invisblle all buttons
        choice2.gameObject.SetActive(false);
        choice3.gameObject.SetActive(false);
        choice4.gameObject.SetActive(false);
        if (todaysEvent == null)
        {
            choice1.GetComponentInChildren<Text>().text = "Error, Default choice only";
            eventDescription.text = "Error, Default event";
            eventName.text = "Error, Default event";
        }
        else
        {
            eventDescription.text = todaysEvent.getDescription();
            eventName.text = todaysEvent.getName();
            List<Options> eventOptions = todaysEvent.eventChosen();
            bool[] results;
            string badStats;
            switch (eventOptions.Count)//enable buttons 2-4 and set each teext value
            {
                case 4:
                    choice4.gameObject.SetActive(true);
                    choice4.interactable = eventOptions[3].isAvailable(player);//if the player does not have the right stats, set the interactability of the button acordinly
                    results = eventOptions[3].missing(player);//results values are related to [stress,homework, exhaustion, money]"
                    badStats = ".";
                    if (results[0])
                    {
                        badStats += " You are too stressed.";
                    }
                    if (results[1])
                    {
                        badStats += " You have too much homework.";
                    }
                    if (results[2])
                    {
                        badStats += " You are too tired.";
                    }
                    if (results[3])
                    {
                        badStats += " You are too broke.";
                    }
                    choice4.GetComponentInChildren<Text>().text = eventOptions[3].name + badStats;
                    goto case 3;
                case 3:
                    choice3.gameObject.SetActive(true);
                    choice3.interactable = eventOptions[2].isAvailable(player);//see above
                    results = eventOptions[2].missing(player);//see above
                    badStats = ".";
                    if (results[0])
                    {
                        badStats += " You are too stressed.";
                    }
                    if (results[1])
                    {
                        badStats += " You have too much homework.";
                    }
                    if (results[2])
                    {
                        badStats += " You are too tired.";
                    }
                    if (results[3])
                    {
                        badStats += " You are too broke.";
                    }
                    choice3.GetComponentInChildren<Text>().text = eventOptions[2].name + badStats;
                    goto case 2;
                case 2:
                    choice2.gameObject.SetActive(true);
                    choice2.interactable = eventOptions[1].isAvailable(player);//see above
                    results = eventOptions[1].missing(player);//see above
                    badStats = ".";
                    if (results[0])
                    {
                        badStats += " You are too stressed.";
                    }
                    if (results[1])
                    {
                        badStats += " You have too much homework.";
                    }
                    if (results[2])
                    {
                        badStats += " You are too tired.";
                    }
                    if (results[3])
                    {
                        badStats += " You are too broke.";
                    }
                    choice2.GetComponentInChildren<Text>().text = eventOptions[1].name + badStats;
                    goto case 1;
                case 1: //case 1 will always be enabled
                    choice1.GetComponentInChildren<Text>().text = eventOptions[0].name;
                    break;
                default:
                    choice1.GetComponentInChildren<Text>().text = "ERROR here!";
                    break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * popup(int i)
     * i: a reference to what button was pressed
     * */
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
        if (todaysEvent == null)
        {
            choiceDescription.text = "ERROR! Default Value";
        }
        else
        {
            string optionTitle;
            List<Options> eventOptions = todaysEvent.eventChosen();
            switch (i)//chose what option had was chosen and update info accordingly 
            {
                case 4:
                    choiceDescription.text = eventOptions[3].text;
                    eventOptions[3].updatePlayer(player);
                    optionTitle = eventOptions[3].name;
                    break;
                case 3:
                    choiceDescription.text = eventOptions[2].text;
                    eventOptions[2].updatePlayer(player);
                    optionTitle = eventOptions[2].name;
                    break;
                case 2:
                    choiceDescription.text = eventOptions[1].text;
                    eventOptions[1].updatePlayer(player);
                    optionTitle = eventOptions[1].name;
                    break;
                case 1:
                    choiceDescription.text = eventOptions[0].text;
                    eventOptions[0].updatePlayer(player);
                    optionTitle = eventOptions[0].name;
                    break;
                default:
                    choiceDescription.text = "ERROR there!";
                    optionTitle = "";
                    break;
            }
            if(optionTitle.Equals("Student Council Unlock"))
            {
                player.unlockStudentCouncil();
            }
            if(optionTitle.Equals("TA Unlock"))
            {
                player.unlockTA();
            }
            if (optionTitle == "Greek Unlock")
            {
                player.unlockGreek();
            }
        }
    }
    /**
     * Back ()
     * Destroys objects and returns to main menu
     **/
    public void back()
    {
        SceneManager.LoadScene(4);
    }
    /**
     * NextDay()
     * load the next day
     * */
    public void NextDay()
    {
        clock.IncrementDay(player.wentToClass, player.startDayLate);
        SceneManager.LoadScene(2);
    }

}
