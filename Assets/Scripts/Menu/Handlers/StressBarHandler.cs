using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressBarHandler : MonoBehaviour {

    Player player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.localScale = new Vector3(((float)player.stress / 100), 1, 1);
    }
}
