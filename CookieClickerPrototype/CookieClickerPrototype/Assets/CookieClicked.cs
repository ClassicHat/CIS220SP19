using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieClicked : MonoBehaviour
{
    public GameObject Cookie;
    public GameObject ValueClicked;
    

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) == true)
        {
            Debug.Log("Cookie Was Clicked");
            Instantiate(ValueClicked);
        }
	}
}
