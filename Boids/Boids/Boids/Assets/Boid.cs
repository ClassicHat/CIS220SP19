using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    // this static list holds all Boid instances and is shared amongst them
    static public List<Boid> boids;
    // Note: this code does NOT use a rigidbody. it handles velocity directly

    public Vector3 velocity;            // The current velocity
    public Vector3 newVelocity;         // The velocity for next frame
    public Vector3 newPosition;         // The position for next frame
    public List<Boid> neighbors;        // All nearby Boids
    public List<Boid> collisionRisks;   // All Boids that are close
    public Boid closest;                // The single closest Boid
    
    // Initialize this Boid on Awake
    void Awake()
    {
        // Define the boids List if it is still null
        if (boids == null)
        {
            boids = new List<Boid>();
        }
        boids.Add(this);

        // Give the boid instance a random position and velocity
        Vector3 randPos = Random.insideUnitSphere * BoidSpawner.S.spawnRadius;
        randPos.y = 0;                                                                  // flatten the Boid to only move in the XZ plane
        this.transform.position = randPos;

        velocity = Random.onUnitSphere;
        velocity *= BoidSpawner.S.spawnVelocity;

        // Initialize the two lists
        neighbors = new List<Boid>();
        collisionRisks = new List<Boid>();

        // Make this.transform a child of the Boids GameObject
        this.transform.parent = GameObject.Find("Boids").transform;

        // Give the Boid a random color, but make sure it is not too dark
        Color randColor = Color.black;
        while (randColor.r + randColor.g + randColor.b < 1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }
        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }

    }

	
	// Update is called once per frame
	void Update () {
        // Get the list of nearby Boids (this Boid's neighbors)
        List<Boid> neighbors = GetNeighbors(this);

        // Initialize newVelocity and newPosition to the current values
        newVelocity = velocity;
        newPosition = this.transform.position;

        // Velocity matching: this sets teh velocity fot he boid to be
        // similar to that of its neighbors
        Vector3 neighborVel = GetAverageVelocity(neighbors);

        // Utilizes the fields set on the BoidSpawner.S Singleton
        newVelocity += neighborVel * BoidSpawner.S.velocityMatchingAmt;

        // Flock Centering: Move toward middle of neighbors
        Vector3 neighborCenterOffset = GetAveragePosition(neighbors) - this.transform.position;

        newVelocity += neighborCenterOffset * BoidSpawner.S.flockCenteringAmt;

        // Collision Avoidance: Avoid running into Boids that are too close
        Vector3 dist;
        if (collisionRisks.Count > 0)
        {
            Vector3 collisionAveragePos = GetAveragePosition(collisionRisks);
            dist = collisionAveragePos - this.transform.position;
            newVelocity += dist * BoidSpawner.S.collisionAvoidanceAmt;
        }

        // Mouse attraction - Move toward the mouse no matter how far away
        dist = BoidSpawner.S.mousePos - this.transform.position;
        if (dist.magnitude > BoidSpawner.S.mouseAvoidanceDist)
        {
            newVelocity += dist * BoidSpawner.S.mouseAttractionAmt;
        }
        else
        {
            // if the mouse is too close, move away quickly!
            newVelocity -= dist.normalized * BoidSpawner.S.mouseAvoidanceDist * BoidSpawner.S.mouseAvoidanceAmt;
        }

        // newVelocity and newPostion are ready, but wait until LateUpdate() 
        // to set them so that this Boid doesn't move before others have
        // had a chance to calculate their new values.

	}
    //
    // by allowing all Boids to Update() themselves before any Boids
    // move, we avoid race conditions that could be caused byt some Boides
    // moving before others have decided where to go

    void LateUpdate()
    {
        // Adjust the current velocity based on newvelocity use a linear
        // interpolation 
        velocity = (1 - BoidSpawner.S.velocityLerpAmt) * velocity + BoidSpawner.S.velocityLerpAmt * newVelocity;
        // make sure the velocity is with allowable limits
        if(velocity.magnitude > BoidSpawner.S.maxVelocity)
        {
            velocity = velocity.normalized * BoidSpawner.S.maxVelocity;
        }
        if (velocity.magnitude < BoidSpawner.S.minVelocity)
        {
            velocity = velocity.normalized * BoidSpawner.S.minVelocity;
        }

        // decide on the new position
        newPosition = this.transform.position + velocity * Time.deltaTime;

        // keep everything on the XZ plane
        newPosition.y = 0;
        // Look from old position at the new position to orient the model
        this.transform.LookAt(newPosition);
        // Actually move to the new position
        this.transform.position = newPosition;
    }

    // Find which Boids are near enough to be considered neighbors
    // boi is BoidOfInterest, the Boid on which we are focusing
    public List<Boid> GetNeighbors (Boid boi)
    {
        float closestDist = float.MaxValue;
        Vector3 delta;
        float dist;
        neighbors.Clear();
        collisionRisks.Clear();

        foreach (Boid b in boids)
        {
            if (b == boi) continue;
            delta = b.transform.position - boi.transform.position;
            dist = delta.magnitude;

            if (dist < closestDist)
            {
                closestDist = dist;
                closest = b;
            }
            if (dist < BoidSpawner.S.nearDist)
            {
                neighbors.Add(b);
            }
            if (dist < BoidSpawner.S.collisionDist)
            {
                collisionRisks.Add(b);
            }
        }
        if (neighbors.Count == 0)
        {
            neighbors.Add(closest);
        }
        return (neighbors);
    }

    // Get the average position of the Boids in a List<Boid>
    public Vector3 GetAveragePosition( List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
        {
            sum += b.transform.position;
        }
        Vector3 center = sum / someBoids.Count;
        return (center);
    }

    // Get the average velocity of the Boids in a List<Boid>
    public Vector3 GetAverageVelocity(List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
        {
            sum += b.velocity;
        }
        Vector3 avg = sum / someBoids.Count;
        return (avg);
    }
}
