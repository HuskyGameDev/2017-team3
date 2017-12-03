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
    /** Back()
     * Destroys objects and returns to main menu
     **/
    public void Back()
    {
        //since these don't destroy on their own, we need to destroy them when they aren't being used
        Destroy(player.gameObject);
        Destroy(clock.gameObject);
        SceneManager.LoadScene(0);

    }
    /** EndDay()
     * Ends the day and go to the next day 
     **/
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
		// Calls task to preform the task
        {
            case 1:
                chosenTask.text = "Workout"; 
				if(player.exhaustion >= 55)
				{
					chosenTask.text = "Too tired to workout";
				}
                player.StressMod(-5);
                break;
            case 2:
                chosenTask.text = "Do Job";
                player.MoneyMod(30);
                break;
            case 3:
                chosenTask.text = "Do Homework";
                player.HomeworkMod(-25);
                player.StressMod(5);
                break;
            case 4:
                if(player.homework > 50)
                {
                    chosenTask.text = "Cannot go out with friends";
                }
                player.StressMod(-25);
                player.ExhaustionMod(10);
                chosenTask.text = "Go out with Friends";
                if (player.money < 5)
                {
                    chosenTask.text = "You are too broke to go out with Friends";
                    return;
                }
                player.StressMod(-25);
                player.MoneyMod(-5);
                player.MoneyMod(-15);
                break;
            case 5:
                chosenTask.text = "Study";
                player.HomeworkMod(-15);
                player.StressMod(10);
                break;
            case 6:
                chosenTask.text = "Play Video Games";
                player.StressMod(-25);
				if(player.homework > 45)
				{
					chosenTask.text = "Cannot play video games"
				}
                player.StressMod(-5);
				player.ExhaustionMod(15);
                break;
            case 7:
                chosenTask.text = "Go Shopping";
                if (player.money < 25)
                {
                    chosenTask.text = "You are too broke to go shopping";
                    return;
                    chosenTask.text = "Cannot go shopping";
                }
                player.MoneyMod(-25);
                player.StressMod(-25);
                break;
            case 8:
                chosenTask.text = "Take a Nap";
                if (startDay < clock.day)
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
