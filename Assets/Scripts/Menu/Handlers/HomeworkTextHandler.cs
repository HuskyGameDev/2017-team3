using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeworkTextHandler : MonoBehaviour {

    public Text txt;
    Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        txt.text = player.homework.ToString() + "/200";
    }
	
	// Update is called once per frame
	void Update ()
    {
        txt.text = player.homework.ToString() + "/200";
    }
}
