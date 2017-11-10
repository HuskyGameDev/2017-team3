using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour {
    Clock clock;
    Player player;
	// Use this for initialization
	void Start () {
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        //TODO display if the player was successful or not as well as end stats
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void back()
    {
        Destroy(player.gameObject);
        Destroy(clock.gameObject);
        SceneManager.LoadScene(0);
    }
}
