using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuHandler : MonoBehaviour {
	public AudioMixerSnapshot normal;
    private const string ADDRESS = "savedData";
    // Use this for initialization
    void Start () {
		normal.TransitionTo (.01f);
		//TODO load previous game data
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void QuitGame()
    {
        //TODO Save player data
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void deleteSaveData()
    {
        if (PlayerPrefs.HasKey(ADDRESS))
        {
            PlayerPrefs.DeleteKey(ADDRESS);
        }
    }
}
