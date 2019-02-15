using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour {
    // This is a Singleton of BoidSpawner. There is only one instance
    // of BoidSpawner, so we can store it in a static variable named S.

    static public BoidSpawner S;

    // These fields allow you to adjust the behavior of the Boids as a group
    public int numBoids = 100;
    public GameObject boidPrefab;
    public float spawnRadius = 100f;
    public float spawnVelocity = 10f;
    public float minVelocity = 0f;
    public float maxVelocity = 30f;
    public float nearDist = 30f;
    public float collisionDist = 5f;
    public float velocityMatchingAmt = 0.01f;
    public float flockCenteringAmt = 0.15f;
    public float collisionAvoidanceAmt = -0.5f;
    public float mouseAttractionAmt = 0.01f;
    public float mouseAvoidanceAmt = 0.75f;
    public float mouseAvoidanceDist = 15f;
    public float velocityLerpAmt = 0.25f;

    public bool ________________;

    public Vector3 mousePos;

    // Use this for initialization
    void Start () {
        // Set the Singleton S to be this instance of BoidSpawner
        S = this;
        // Instantiate numBoids Boids
        for (int i = 0; i < numBoids; i++)
        {
            Instantiate(boidPrefab);
            print ("in for loop" + i);
        }
	}
	
	// LateUpdate is called once per frame, after all Update methods have been processed
	void LateUpdate () {
        // Track the mouse position. This keeps it the same for all Boids.
        Vector3 mousePos2d = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.y);
        Camera camera = GetComponent<Camera>();
        mousePos = camera.ScreenToWorldPoint(mousePos2d);
    }
}
