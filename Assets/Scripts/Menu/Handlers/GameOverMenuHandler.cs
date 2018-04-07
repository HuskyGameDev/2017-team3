using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameOverMenuHandler : MonoBehaviour {
    Clock clock;
    Player player;
    public Text results;
	public AudioMixerSnapshot gameover;
    // Use this for initialization
    void Start () {
        //get reference to the clock and player objects
        clock = (Clock)GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
        player = (Player)GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
		gameover.TransitionTo (.05f);

 
        //see if anything is unlocked
        UnlockRewards unlocking = new UnlockRewards();
        Unlocked data = new Unlocked();
        unlocking.unlock(player, clock, data);

        //display results. 
        //TODO Change these into progress bars
        results.text = "Results for " + player.PlayerName + ":\nStress: " + player.stress.ToString()
            + "/100\nHomework: " + player.homework.ToString()
            + "/200\nMoney: $" + player.money.ToString()
            + "\nStrength: " + player.strength.ToString()
            + "/100\nDexterity: " + player.dexterity.ToString()
            + "/100\nConstitution: "+player.constitution.ToString()
            + "/100\nWisdom: " +player.wisdom.ToString()
            + "/100\nIntelligence: "+player.intelligence.ToString()
            + "/100\nCharisma: "+player.charisma.ToString()
            + "/100\nFriends: " + player.friends.ToString()
            + "/100\nFamily: "+player.family.ToString()
            + "/100\nUnlocked:";
        // display what was unlocked
        if (data.endless)
            results.text += "\nEndless Mode";
        if (data.student_Council)
            results.text += "\nStudent Council Class";
        if (data.athlete)
            results.text += "\nAthlete Class";
        if (data.cheer)
            results.text += "\nCheer Class";
        if (data.band)
            results.text += "\nBand Class";
        if (data.nerd)
            results.text += "\nNerd Class";
        if (data.TA)
            results.text += "\nTeacher's Assistant Class";
        if (data.greek)
            results.text += "\nGreek Class";
        if (data.hidden)
            results.text += "\nAnd you found the Stoner Class.... Great....";
        if (data.tryHard)
            results.text += "\nTryHard Class";
        if (data.rich_Kid)
            results.text += "\nRick Kid Class";
        if (data.microManaged)
            results.text += "\nMicroManaged Class";
        if (data.otaku)
            results.text += "\nOtaku Class";
        if (data.ROTC)
            results.text += "\nROTC Class";
        if (data.GOD)
            results.text += "\nGOD Class";
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
        XML_Save save = new XML_Save(player.data);
        //TODO save data here if something was unlocked or new high score
        Destroy(player.gameObject);
        Destroy(clock.gameObject);
        SceneManager.LoadScene(0);
    }
}
