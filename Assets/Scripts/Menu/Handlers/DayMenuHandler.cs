using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayMenuHandler : MonoBehaviour {
    public Text chosenTask;
    public Text TempClock;
    public Toggle goToClass;
    public Text TempBars;
    Clock clock;
    Player player;
    int startDay;
    // Use this for initialization
    void Awake()
    {
        clock = GameObject.FindGameObjectWithTag ( "Clock" ).GetComponent<Clock>();
        player =GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        startDay = clock.day;
        if (player.wentToClass)
        {
            player.exhaustion = 20;
        }
        else
        {
            player.exhaustion = 0;

        }
        
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        TempClock.text = "Day: " + clock.day + "\n Time:" + clock.time;
        TempBars.text = "Money: " + player.money + "\n Exhaustion: " + player.exhaustion + "\n Stress: " + player.stress + "\n Homework" + player.homework;
	}
    public void Back()
    {
        //since these don't destroy on their own, we need to destroy them when they aren't being used
        Destroy(player);
        Destroy(clock);
        SceneManager.LoadScene(0);

    }
    public void EndDay()
    {
        player.wentToClass = goToClass.isOn;
        SceneManager.LoadScene(3);
    }
    public void PerformTask(int i)
    {
        //if the player is completely exausted, stop them from doing anything
        if (player.exhaustion>=100)
        {
            chosenTask.text = "No More Energy";
            return;
        }
        //TODO Stop people from napping after midnight
        //determine what button was clicked
        switch (i)
        {
            case 1:
                chosenTask.text = "Go to Class:" + i.ToString();  // Calls task to preform the task
                break;
            case 2:
                chosenTask.text = "Skip Class:" + i.ToString();
                break;
            case 3:
                chosenTask.text = "Do Homework:" + i.ToString();
                break;
            case 4:
                chosenTask.text = "Go out with friends:" + i.ToString();
                break;
            case 5:
                chosenTask.text = "Study:" + i.ToString();
                break;
            case 6:
                chosenTask.text = "Play video games:" + i.ToString();
                break;
            case 7:
                chosenTask.text = "Do nothing:" + i.ToString();
                break;
            case 8:
                chosenTask.text = "Take a nap:" + i.ToString();
                break;
            default:
                chosenTask.text = "This shouldn't happen";
                break;
        }
        //each action takes 1 hour
        clock.ChangeHour(1);
        //after midnight, actions take more and more energy to perform
        int mult = 1;
        if (startDay < clock.day)
        {
            mult = clock.time;
        }
        player.ExhaustionMod(10*mult);
    }
}
