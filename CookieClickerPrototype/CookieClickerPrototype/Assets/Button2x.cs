using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2x : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeClickValue()
    {
        TotalCookies.ClickValue *= 2;
    }
}
