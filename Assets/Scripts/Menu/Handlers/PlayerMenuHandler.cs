using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuHandler : MonoBehaviour {
    public Text Selection;
    public InputField nameInput;
    public Text namefield;
    Clock clock;
    Player player;
    // Use this for initialization
    void Start () {
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
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
        Destroy(player);
        Destroy(clock);
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        player.PlayerName = nameInput.text;
        SceneManager.LoadScene(2);
    }
}
