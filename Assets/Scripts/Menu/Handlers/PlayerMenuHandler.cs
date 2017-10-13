using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuHandler : MonoBehaviour {
    public Text Selection;
    public InputField nameInput;
    public Text namefield;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        namefield.text = "Player name: \n"+nameInput.text;
	}
    public void ChangeText(string input)
    {
        Selection.text = "Chosen Class: " +input;
    }
    public void back()
    {
        //TODO Save player data
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
