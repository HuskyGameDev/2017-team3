using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenuHandler : MonoBehaviour {
    bool showWindow = false;
    public Popup popupmenu;
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
