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

        //get the current mouse position in 2D screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Find the delta position from the launch pos to the mousePos3D
        Vector3 mouseDelta = mousePos3D - launchPos;        //vector subtraction
        //Limit mouse delta to the radius of the slingshot sphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }//End if

        //Move the projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;       //vector addition
        projectile.transform.position = projPos;        //move projectile to the new position

        if(Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;     //Set POI for our camera
            projectile = null;
        }//End if
    }//End Update Method

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
