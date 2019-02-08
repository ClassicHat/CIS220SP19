using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //static variable - only one of these for all apples
    public static float bottomY = -20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //if we are past the bottom destroy the apple
	    if (transform.position.y < bottomY)
	    {
	        Destroy(this.gameObject);
	        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
	        apScript.AppleDestroyed();
	    }
	}
}
