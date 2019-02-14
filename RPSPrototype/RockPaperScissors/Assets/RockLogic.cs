using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLogic : MonoBehaviour
{
    //Inspector Variables
    public GameObject rockPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(rockPrefab, 5);	
	}
}
