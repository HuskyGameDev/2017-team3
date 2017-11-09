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
        if (player.wentToClass)     //increases player exhaustion when going to class
        {
            player.exhaustion = 20;
        }
        else
        {
            player.exhaustion = 0;

        }
        
    }
    void Start () {
        player.homework += 1; //todo decide what homework value this should be
	}
	
	// Update is called once per frame
	void Update () {

        TempClock.text = "Day: " + clock.day + "\n Time:" + clock.time;
        TempBars.text = player.PlayerName +"\nMoney: " + player.money + "\nExhaustion: " + player.exhaustion + "\nStress: " + player.stress + "\nHomework: " + player.homework;
        if (player.homework >= 200 || (player.stress >= 100 && player.exhaustion >= 100))
        {
            SceneManager.LoadScene(4);
        }
        if (player.stress > 100)
        {
            player.stress = 100;
        }
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
                chosenTask.text = "Workout";  // Calls task to preform the task
                player.StressMod(-5);
                break;
            case 2:
                chosenTask.text = "Do Job";     
                player.MoneyMod(30);
                break;
            case 3:
                chosenTask.text = "Do Homework";
                player.HomeworkMod(-25);        //Affects player stats
                player.StressMod(15);
                break;
            case 4:
                chosenTask.text = "Go out with Friends";
                player.StressMod(-15);
                player.MoneyMod(-15);
                break;
            case 5:
                chosenTask.text = "Study";
                player.HomeworkMod(-15);
                player.StressMod(20);
                break;
            case 6:
                chosenTask.text = "Play Video Games";
                player.StressMod(-5);
                break;
            case 7:
                chosenTask.text = "Go Shopping";
                if (player.money < 25)             //if the players money is less than the assigned variable you cannot perform the shopping action
                {
                    chosenTask.text = "Cannot go shopping";
                    return;
                }
                player.MoneyMod(-25);
                player.StressMod(-25);
                break;
            case 8:
                chosenTask.text = "Take a Nap";
                if (startDay < clock.day)           //if the start clock is more than the actual time, end the day
                {
                    EndDay();
                }
                clock.ChangeHour(1);
                player.ExhaustionMod(-5);
                return;
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
        if(player.stress>50 && player.stress < 75)
        {
            mult *= 2;
        }
        if (player.stress > 75 && player.stress<100)
        {
            mult *= 3;
        }
        if (player.stress >= 100)
        {
            mult *= 4;
        }
        player.ExhaustionMod(10*mult);
    }
}
