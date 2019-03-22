using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCookies : MonoBehaviour
{
    public Text totalCookies;
    public double cValue;
    public static double ClickValue = 1;

	// Use this for initialization
	void Start ()
    {
        //Find a reference to the cookie counter
        GameObject cookies = GameObject.Find("TotalCookies");

        //Get the text component from the GameObject
        totalCookies = cookies.GetComponent<Text>();
    }
	
    public void UpdateTotalCookies()
    {
        //parse the text of the total cookies into an int
        double cookies = double.Parse(totalCookies.text);

        //Add points for each click
        cookies += ClickValue;

        //Convert back to string
        totalCookies.text = cookies.ToString();
        cValue = ClickValue;
    }
}
