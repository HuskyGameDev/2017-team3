using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageSelector : MonoBehaviour {
    public GameObject obj;
    Image img;

	// Use this for initialization
	void Start () {
        img = obj.GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void SelectPlayer(int s)
    {
        switch (s)
        {

        }
    }
}
