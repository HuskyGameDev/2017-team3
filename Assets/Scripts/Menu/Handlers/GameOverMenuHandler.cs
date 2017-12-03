using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour {
    Clock clock;
    Player player;
	// Use this for initialization
	void Start () {
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        //TODO display if the player was successful or not as well as end stats
        UnlockRewards 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /**
     * Back ()
     * Destroys objects and returns to main menu
     **/
    public void back()
    {
        //TODO save data here if something was unlocked or new high score
        Destroy(player.gameObject);
        Destroy(clock.gameObject);
        SceneManager.LoadScene(0);
    }
}
