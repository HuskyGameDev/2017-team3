using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenuHandler : MonoBehaviour {
    bool showWindow = false;
    public Popup popupmenu;
    // Use this for initialization
    void Start () {
		
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
        //TODO Save player data
        SceneManager.LoadScene(0);
    }
    public void NextDay()
    {
        SceneManager.LoadScene(2);
    }

}
