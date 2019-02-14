using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorLogic : MonoBehaviour
{
    //Inspector Variables
    public GameObject scissorPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(scissorPrefab, 5);
	}
}
