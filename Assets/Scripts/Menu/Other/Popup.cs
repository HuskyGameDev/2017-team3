using UnityEngine;

public class Popup : MonoBehaviour{
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void toggleActive(bool active)
    {
        gameObject.SetActive(active);

    }
}
