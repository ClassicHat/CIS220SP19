using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSLogic : MonoBehaviour
{
    //Global Variables
    public GameObject paperPrefab;
    public GameObject rockPrefab;
    public GameObject scissorsPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject playerChoice = ChooseFighter();
        GameObject aIChoice = AIChoice();

        Winner(playerChoice, aIChoice);

    }//End Update

    public void Winner(GameObject player, GameObject aI)
    {
        if(player.GetComponent("paperPrefab") && aI.GetComponent("scissorPrefab"))
        {
            
        }
    }

    public GameObject ChooseFighter()
    {
        //Looks for input by pressing keys P, R, or S.
        bool paper = Input.GetKeyDown(KeyCode.P);
        bool rock = Input.GetKeyDown(KeyCode.R);
        bool scissors = Input.GetKeyDown(KeyCode.S);
        GameObject playerChoice = paperPrefab;

        if (paper)
        {
            playerChoice = paperPrefab;
            //Instantiate(paperPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (rock)
        {
            playerChoice = rockPrefab;
            //Instantiate(rockPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (scissors)
        {
            playerChoice = scissorsPrefab;
            //Instantiate(scissorsPrefab, new Vector3(0, 4, 0), Quaternion.identity);
        }

        return playerChoice;
    }//End ChooseFighter

    public GameObject AIChoice()
    {
        GameObject aIChoice;
        int number = Random.Range(1, 3);

        if(number == 1)
        {
            aIChoice = paperPrefab;
        }
        else if (number == 2)
        {
            aIChoice = rockPrefab;
        }
        else
        {
            aIChoice = scissorsPrefab;
        }

        return aIChoice;
    }//End AIChoice

}//End Class
