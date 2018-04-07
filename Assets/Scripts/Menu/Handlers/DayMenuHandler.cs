﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class DayMenuHandler : MonoBehaviour
{
    public Text chosenTask;
    public Text TempClock;
    public Toggle goToClass;
    public Text TempBars;
    Clock clock;
    Player player;
    int startDay;

    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot level1;
    public AudioMixerSnapshot level2;
    public AudioMixerSnapshot level3;
    public AudioMixerSnapshot level4;
    public AudioMixerSnapshot level5;
    public AudioMixerSnapshot level6;




    private const int NORMAL_EXHAUSTION_MOD = 4;
    private const int MIDNIGHT_OIL_EXHAUSTION_MOD = 10;


    // Use this for initialization
    void Awake()
    {
        clock = GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        startDay = clock.day;
        if (!clock.endless && clock.day > 75)
        {
            SceneManager.LoadScene(4);
        }
        if (player.startDayLate)
        {
            goToClass.interactable = false;
            (goToClass.GetComponentInChildren<Text>()).text = "Student Athletes must go to class";
            player.exhaustion = 40;
        }
        else if (player.wentToClass)
        {
            player.exhaustion = 20;
        }
        else
        {
            player.exhaustion = 0;
            System.Random random = new System.Random();
            player.HomeworkMod(random.Next(0, 20));

        }

    }
    void Start()
    {
        player.homework += 5; //todo decide what homework value this should be
        if (player.Rich)
        {
            if (player.family < 10)//todo decide this value
            {
                //TODO display popup letting player know this will happen
                player.money = 0;
                player.Rich = false;
            }
        }
    }


    void MusicCheck(int stress, int exhaustion)
    {
        if (stress >= 90 && exhaustion >= 90)
        {
            level6.TransitionTo(0.01F);
            return;
        }
        if (stress >= 80 && exhaustion >= 80)
        {
            level5.TransitionTo(0.01F);
            return;
        }
        if (stress >= 70 && exhaustion >= 70)
        {
            level4.TransitionTo(0.01F);
            return;
        }
        if (stress >= 60 && exhaustion >= 60)
        {
            level3.TransitionTo(0.01F);
            return;
        }
        if (stress >= 50 && exhaustion >= 50)
        {
            level2.TransitionTo(0.01F);
            return;
        }
        if (stress >= 30 && exhaustion >= 30)
        {
            level1.TransitionTo(0.01F);
            return;
        }

        normal.TransitionTo(0.01F);
        return;

    }


    // Update is called once per frame
    void Update()
    {
        TempClock.text = "Day: " + clock.day + "\n Time:" + clock.time;
        TempBars.text = player.PlayerName + "\nMoney: " + player.money + "\nExhaustion: " + player.exhaustion + "\nStress: " + player.stress + "\nHomework: " + player.homework;
        if (player.homework >= 200 || (player.stress >= 100 && player.exhaustion >= 100))
        {
            SceneManager.LoadScene(4);
        }
        if (player.stress > 100)
        {
            player.stress = 100;
        }


        MusicCheck(player.stress, player.exhaustion);

    }
    /** Back()
     * Destroys objects and returns to main menu
     **/
    public void Back()
    {
        SceneManager.LoadScene(5);
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
        if (player.exhaustion >= 100)
        {
            chosenTask.text = "No More Energy";
            return;
        }
        if (player.GOD)
        {
            player.MoneyMod(30);
        }
        //determine what button was clicked
        switch (i)
        // Calls task to preform the task
        {
            case 1:
                chosenTask.text = "Workout";
                if (player.exhaustion >= 55)
                {
                    chosenTask.text = "Too tired to workout";
                    return;
                }
                player.ChangeStr(2);
                player.ChangeDex(2);
                player.StressMod(-5);
                player.ExhaustionMod(10);
                break;
            case 2:
                chosenTask.text = "Do Job";
                if (player.TA)
                {
                    player.MoneyMod(60);
                }
                else if (player.Otaku)
                {
                    player.MoneyMod(15);
                }
                else
                {
                    player.MoneyMod(30);
                }
                if (player.GOD)
                {
                    player.StressMod(-5);
                }
                else
                {
                    player.StressMod(5);
                }
                break;
            case 3:
                if (player.Hidden)
                {
                    chosenTask.text = "To high to do Homework";
                    return;
                }
                if (player.homework == 0)
                {
                    chosenTask.text = "You have no homework";
                    return;
                }
                chosenTask.text = "Do Homework";
                player.ChangeInt(1);
                player.ChangeWis(1);
                player.HomeworkMod(-10);
                player.StressMod(5);
                break;
            case 4:
                if (player.homework > 50)
                {
                    chosenTask.text = "Cannot go out with friends";
                    return;
                }
                if (player.money < 5)
                {
                    chosenTask.text = "You are too broke to go out with Friends";
                    return;
                }
                player.ExhaustionMod(3);
                chosenTask.text = "Go out with Friends";
                player.ChangeFri(2);
                player.ChangeFam(2);
                player.StressMod(-25);
                player.MoneyMod(-15);
                break;
            case 5:
                if (player.Hidden)
                {
                    chosenTask.text = "You are too high to study.";
                    return;
                }
                chosenTask.text = "Study";
                player.HomeworkMod(-15);
                player.ChangeInt(2);
                player.ChangeWis(2);
                if (player.GOD)
                {
                    player.StressMod(-10);
                }
                else
                {
                    player.StressMod(10);
                }
                break;
            case 6:
                if (player.homework > 45)
                {
                    chosenTask.text = "Cannot play video games";
                    return;
                }
                chosenTask.text = "Play Video Games";
                player.StressMod(-25);
                player.StressMod(-5);
                player.ExhaustionMod(5);
                break;
            case 7:
                chosenTask.text = "Go Shopping";
                if (player.money < 25)
                {
                    chosenTask.text = "You are too broke to go shopping";
                    return;
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
                player.ExhaustionMod(-10);
                if (player.GOD)
                {
                    player.StressMod(-5);
                }
                clock.ChangeHour(1);
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
        if (player.stress > 50 && player.stress < 75)
        {
            mult *= 2;
        }
        if (player.stress > 75 && player.stress < 100)
        {
            mult *= 3;
        }
        if (player.stress >= 100)
        {
            mult *= 4;
        }
        int exhaustionMod = (!player.GOD && startDay < clock.day) ? MIDNIGHT_OIL_EXHAUSTION_MOD : NORMAL_EXHAUSTION_MOD;
        player.ExhaustionMod(exhaustionMod * mult);
    }
}
