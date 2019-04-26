using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour {
    [Header("Block Options")]
    public float digits = 0;
    public float count = 0;

    //Private Class Fields
    private GameObject smallBlock;
    private GameObject bigBlock;

	// Use this for initialization
	void Start () {
        //Get references to the small block
        smallBlock = GameObject.FindGameObjectWithTag("SmallBlock");
        BlockSetUp(smallBlock);
        
        //Get reference to the big block
        bigBlock = GameObject.FindGameObjectWithTag("BigBlock");
        BlockSetUp(bigBlock);
        bigBlock.GetComponent<Block>().mass = Mathf.Pow(100, digits - 1);
    }

    public void BlockSetUp(GameObject theBlock)
    {
        theBlock.GetComponent<Block>().XPos = theBlock.transform.position.x;
        theBlock.GetComponent<Block>().YPos = theBlock.transform.position.y;
        theBlock.GetComponent<Block>().ZPos = theBlock.transform.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveBlock(bigBlock);
        MoveBlock(smallBlock);


        if (bigBlock.GetComponent<Block>().IsCollide(smallBlock.GetComponent<Block>(), 1))
        {
            float v1 = smallBlock.GetComponent<Block>().Bounce(bigBlock.GetComponent<Block>());
            float v2 = bigBlock.GetComponent<Block>().Bounce(smallBlock.GetComponent<Block>());
            smallBlock.GetComponent<Block>().Velocity = v1;
            bigBlock.GetComponent<Block>().Velocity = v2;
            count += 1;
        }

        bool hitWall = smallBlock.GetComponent<Block>().HitWall();
        if(hitWall == true)
        {
            count++;
        }
    }

    void MoveBlock(GameObject theBlock)
    {
        //Update the big and small blocks
        theBlock.GetComponent<Block>().XPos += theBlock.GetComponent<Block>().Velocity;
        Vector3 theVector = new Vector3(theBlock.GetComponent<Block>().XPos, 0, 0);
        theBlock.transform.position = theVector;
        BlockSetUp(theBlock);
    }
}
