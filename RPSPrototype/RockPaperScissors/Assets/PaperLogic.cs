using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperLogic : MonoBehaviour
{
    //Inspector Variables
    public GameObject paperPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(paperPrefab, 5);	
	}
}
