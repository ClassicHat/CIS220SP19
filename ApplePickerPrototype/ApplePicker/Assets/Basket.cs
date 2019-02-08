using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

	// Use this for initialization
	void Start ()
	{
        //Find a reference to the score counter
	    GameObject scoreGO = GameObject.Find("ScoreCounter");

        //Get the text component from the GameObject
	    scoreGT = scoreGO.GetComponent<Text>();

        //Set the starting number of points to 0
	    scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Get the current screen position of the mouse
	    Vector3 mousePos2D = Input.mousePosition;

	    mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D space to 3D game world
	    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the X postion of the basket to the X poistion of the mouse
	    Vector3 pos = this.transform.position;
	    pos.x = mousePos3D.x;
	    this.transform.position = pos;

	}//End Update Method

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            //parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);

            //add points for catching an apple
            score += 100;

            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();

            //Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }//End if

        }//End if
    }//End OnColisionEnter

}//End Class
