using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressTextHandler : MonoBehaviour {

    public Text txt;
    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
        txt.text = player.stress.ToString() + "/1000";
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = player.stress.ToString() + "/1000";
    }
}
