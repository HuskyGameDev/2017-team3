using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuHandler : MonoBehaviour {
    Clock clock;
    Player player;
    public Text results;
    // Use this for initialization
    void Start () {
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        //TODO display if the player was successful or not as well as end stats
        UnlockRewards unlocking = new UnlockRewards();
        Unlocked data = new Unlocked();
        unlocking.unlock(player, clock, data);
        results.text = "Results for " + player.name + ":\nStress: " + player.stress.ToString()
            + "/100\nHomework: " + player.homework.ToString()
            + "/200\nMoney: $" + player.money.ToString()
            + "\nStrength: " + player.strength.ToString()
            + "/100\nDexterity: " + player.dexterity.ToString()
            + "/100\nConstitution: "+player.constitution.ToString()
            + "/100\nWisdom: " +player.wisdom.ToString()
            + "/100\nIntelligence: "+player.intelligence.ToString()
            + "/100\nCharisma: "+player.charisma.ToString()
            + "/100\nFriends: ";
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
