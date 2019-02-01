using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Class level variables (Inspector Variables)
    //Prefab for instatiating apples
    public GameObject applePrefab;
    //Speed at which the apple tree moves
    public float speed = 1f;
    //Distance where the apple tree turns around
    public float leftAndRightEdge = 25f;
    //Chance that the apple tree will change directions
    public float chanceToChangeDirections = 0.1f;
    //Rate at which apple will be instatiated
    public float secondsBetweenAppleDrops = 1f;

	// Use this for initialization
	void Start ()
	{
		//Drop apples every second
	    Invoke("DropApple", 2f);
	}

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
	
	// Update is called once per frame
	void Update ()
	{
        //Basic movement accros the screen
	    Vector3 pos = transform.position;   //Saving x,y,z poistion
	    pos.x += speed * Time.deltaTime;
	    transform.position = pos;

        //Changing direction
	    if (pos.x < -leftAndRightEdge)
	    {
	        speed = Mathf.Abs(speed);   //Move Right
	    }
        else if (pos.x > leftAndRightEdge)
	    {
	        speed = -Mathf.Abs(speed);  //Move Left
	    }
        
	}

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

}
