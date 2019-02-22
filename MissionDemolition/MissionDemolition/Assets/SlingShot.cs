using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour {
    //Inspector Variables
    [Header("Set In Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    private Rigidbody projectileRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }//End Awake Method

    void Update()
    {
        //If slingshot is not in aiming mode, dont run code
        if (!aimingMode) return;    //Bad code
    }

    void OnMouseDown()
    {
        //The player has pressed the mouse button while over the slingshot
        aimingMode = true;
        //Instatiate a projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        //Start at the launch point
        projectile.transform.position = launchPos;
        //Set it to isKinematic for now
        ////projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }//End OnMouseDown Method

    void OnMouseEnter ()
	{
	    //print("Slingshot : OnMouseEnter()");
	    launchPoint.SetActive(true);
	}//End OnMouseEnter Method
	
	void OnMouseExit ()
	{
        //print("Slingshot : OnMouseExit()");
	    launchPoint.SetActive(false);
    }//End OnMouseExit Method
}
