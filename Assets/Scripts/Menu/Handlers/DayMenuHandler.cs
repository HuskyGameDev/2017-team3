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
                chosenTask.text = "Workout";  // Calls task to preform the task
                if (player.exhaustion >= 55)
                {
                    chosenTask.text = "Too tired to workout";
                }
                player.ExhaustionMod(10);
                player.StressMod(-5);
                break;
            case 2:
                chosenTask.text = "Do Job";
                player.MoneyMod(30);
                player.ExhaustionMod(15);
                break;
            case 3:
                chosenTask.text = "Do Homework";
                player.HomeworkMod(-25);
                player.ExhaustionMod(10);
                player.StressMod(5);
                break;
            case 4:
                chosenTask.text = "Go out with Friends";
                if (player.homework > 50)
                {
                    chosenTask.text = "Cannot go out with Friends";
                }
                player.StressMod(-25);
                player.ExhaustionMod(10);
                player.MoneyMod(-5);
                break;
            case 5:
                chosenTask.text = "Study";
                player.HomeworkMod(-15);
                player.StressMod(10);
                player.ExhaustionMod(10);
                break;
            case 6:
                chosenTask.text = "Play Video Games";
                if (player.homework > 45)
                {
                    chosenTask.text = "Cannot play video games";
                }
                player.StressMod(-25);
                player.ExhaustionMod(10);
                break;
            case 7:
                chosenTask.text = "Go Shopping";
                if (player.money < 25)
                {
                    chosenTask.text = "Cannot go shopping";
                }
                player.MoneyMod(-25);
                player.StressMod(-25);
                break;
            case 8:
                chosenTask.text = "Take a Nap";
                if (clock.day >= 12)
                {
                    EndDay();
                }
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
