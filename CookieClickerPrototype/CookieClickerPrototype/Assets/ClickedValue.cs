using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedValue : MonoBehaviour
{
    public Text score;
    public GameObject ClickValue;

    // Use this for initialization
    void Start ()
    {
        //Find a reference to the clickedValue gameobject
        GameObject scoreGet = GameObject.Find("ClickedValue");

        //Get the text component from the GameObject
        score = scoreGet.GetComponent<Text>();

        //Set the starting number of points to +1
        score.text = "+1";
    }
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(ClickValue, 1);
    }
}
