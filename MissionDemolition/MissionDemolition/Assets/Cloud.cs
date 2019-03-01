using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject cloudSphere;
    public int numSphereMin = 6;
    public int numSphereMax = 10;
    public Vector3 sphereOffSetScale = new Vector3(5, 2, 1);
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 4);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 4);
    public float scaleYMin = 2f;

    private List<GameObject> spheres;

	// Use this for initialization
	void Start ()
    {
        spheres = new List<GameObject>();
        //Set up a random number of clouds
        int num = Random.Range(numSphereMin, numSphereMax);
        //Generate clouds up to num
        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            spheres.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            //Randomly assign a position
            Vector3 offSet = Random.insideUnitSphere;
            offSet.x *= sphereOffSetScale.x;
            offSet.y *= sphereOffSetScale.y;
            offSet.z *= sphereOffSetScale.z;
            spTrans.localPosition = offSet;

            //Randomly assign scale
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.x = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.x = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

            //adjust y scale by x distance from core
            scale.y *= 1 - (Mathf.Abs(offSet.x) / sphereOffSetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);
            spTrans.localScale = scale;
        }//End for loop
	}//End Start method
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
	}

    void Restart()
    {
        //Clear out old spheres
        foreach (GameObject sp in spheres)
        {
            Destroy(sp);
        }//End foreach

        Start();
    }//End Restart Method
}
