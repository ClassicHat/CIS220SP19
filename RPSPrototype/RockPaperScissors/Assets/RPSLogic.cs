using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPSLogic : MonoBehaviour
{
    //Global Variables
    public GameObject paperPrefab;
    public GameObject rockPrefab;
    public GameObject scissorsPrefab;
    public Text messageChange;

    // Use this for initialization
    void Start ()
    {
        //Find a reference to the message text
        GameObject message = GameObject.Find("Message");

        //Get the text component from the GameObject
        messageChange = message.GetComponent<Text>();

        //Set the starting message
        messageChange.text = "Pick P for Paper, Pick R for Rock, And Pick S for Scissors!";
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject playerChoice = ChooseFighter();

        if (playerChoice != null)
        {
            GameObject aIChoice = AIChoice();

            if(playerChoice == scissorsPrefab)
            {
                Instantiate(playerChoice, new Vector3(-8, 4, 0), Quaternion.identity);
            }
            else if(playerChoice == paperPrefab || playerChoice == rockPrefab)
            {
                Instantiate(playerChoice, new Vector3(-10, 0, 0), Quaternion.identity);
            }//End if / else

            if (aIChoice == scissorsPrefab)
            {
                Instantiate(aIChoice, new Vector3(8, 4, 0), Quaternion.identity);
            }
            else if(aIChoice == rockPrefab || aIChoice == paperPrefab)
            {
                Instantiate(aIChoice, new Vector3(10, 0, 0), Quaternion.identity);
            }//End if / else

            Winner(playerChoice, aIChoice);
            playerChoice = null;
        }//End if
        
    }//End Update

    /// <summary>
    /// Expects: The player's GameObject and the AI's GameObject.
    /// Returns: Nothing
    /// Tasks: Compares the two game objects to see who beats who.
    ///     Paper beats Rock, Rock beats Scissors, Scissors beats Paper.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="aI"></param>
    public void Winner(GameObject player, GameObject aI)
    {
        //All the ways the player can lose
        if(player == paperPrefab)
        {
            if(aI == rockPrefab)
            {
                messageChange.text = "You Win; Paper Covers Rock!";
            }
            else if(aI == scissorsPrefab)
            {
                messageChange.text = "You Lose; Paper Gets Cut By Scissors!";
            }
            else
            {
                messageChange.text = "It's A Tie; Paper And Paper!";
            }//End if / if else / else
        }
        else if(player == rockPrefab)
        {
            if (aI == paperPrefab)
            {
                messageChange.text = "You Lose; Rock Gets Covered By Paper!";
            }
            else if (aI == scissorsPrefab)
            {
                messageChange.text = "You Win; Rock Crushes Scissors!";
            }
            else
            {
                messageChange.text = "It's A Tie; Rock And Rock!";
            }//End if / if else / else
        }
        else if(player == scissorsPrefab)
        {
            if (aI == paperPrefab)
            {
                messageChange.text = "You Win; Scissors Cuts Paper!";
            }
            else if (aI == rockPrefab)
            {
                messageChange.text = "You Lose; Scissors Gets Crushed By Rock!";
            }
            else
            {
                messageChange.text = "It's A Tie; Scissors And Scissors!";
            }//End if / if else / else
        }//End if / else if / else if
    }//End Winner

    /// <summary>
    /// Expects: Nothing
    /// Returns: The players choice
    /// Tasks: Using an input identifier, this method looks for the pressing of
    ///     the R, P, or S key and then returns the coresponding GameObject
    ///     prefab. R = RockPrefab, P = PaperPrefab, S = ScissorPrefab.
    /// </summary>
    /// <returns></returns>
    public GameObject ChooseFighter()
    {
        //Looks for input by pressing keys P, R, or S.
        bool paper = Input.GetKeyDown(KeyCode.P);
        bool rock = Input.GetKeyDown(KeyCode.R);
        bool scissors = Input.GetKeyDown(KeyCode.S);
        GameObject playerChoice = null;

        if (paper)
        {
            playerChoice = paperPrefab;
        }
        else if (rock)
        {
            playerChoice = rockPrefab;
        }
        else if (scissors)
        {
            playerChoice = scissorsPrefab;
        }

        return playerChoice;
    }//End ChooseFighter

    /// <summary>
    /// Expects: Nothing
    /// Returns: The AI choice
    /// Tasks: Gets a random number between 1 and 3 and then returns the AI's choice.
    ///     1 = PaperPrefab, 2 = RockPrefab, 3 or else = ScissorPrefab.
    /// </summary>
    /// <returns></returns>
    public GameObject AIChoice()
    {
        GameObject aIChoice;
        int number = Random.Range(1, 4);

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
