using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayMenuHandler : MonoBehaviour {
    public Text chosenTask;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Back()
    {
        //TODO Save player data
        SceneManager.LoadScene(0);
    }
    public void EndDay()
    {
        SceneManager.LoadScene(3);
    }
    public void PerformTask(int i)
    {
        switch (i)
        {
            case 1:
                chosenTask.text = "Go to Class:" + i.ToString();  // Calls task to preform the task
                break;
            case 2:
                chosenTask.text = "Skip Class:" + i.ToString();
                break;
            case 3:
                chosenTask.text = "Do Homework:" + i.ToString();
                break;
            case 4:
                chosenTask.text = "Go out with friends:" + i.ToString();
                break;
            case 5:
                chosenTask.text = "Study:" + i.ToString();
                break;
            case 6:
                chosenTask.text = "Play video games:" + i.ToString();
                break;
            case 7:
                chosenTask.text = "Do nothing:" + i.ToString();
                break;
            case 8:
                chosenTask.text = "Take a nap:" + i.ToString();
                break;
            default:
                chosenTask.text = "This shouldn't happen";
                break;
                break;
        }
    }
}
