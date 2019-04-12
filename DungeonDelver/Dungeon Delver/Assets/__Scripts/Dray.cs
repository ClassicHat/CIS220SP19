using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dray : MonoBehaviour {
    [Header("Set In Inspector")]
    public float speed = 5;

    [Header("Set Dynamically")]
    public int dirHeld = -1;

    private Rigidbody rigid;

	// Use this for initialization
	void Awake () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        dirHeld = -1;   //Reinitialise variable

        if(Input.GetKey(KeyCode.RightArrow))
        {
            dirHeld = 0;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            dirHeld = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirHeld = 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dirHeld = 3;
        }

        Vector3 vel = Vector3.zero;


        switch(dirHeld)
        {
            case 0:
                vel = Vector3.right;
                break;
            case 1:
                vel = Vector3.up;
                break;
            case 2:
                vel = Vector3.left;
                break;
            case 3:
                vel = Vector3.down;
                break;
        }//End Switch

        rigid.velocity = vel * speed;

    }//End Update Method
}
