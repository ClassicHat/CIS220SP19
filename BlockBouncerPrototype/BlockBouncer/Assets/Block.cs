using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    //Private Class Fields
    public float velocity;
    private float xPos;
    private float yPos;
    private float zPos;
    public float mass = 1;

    //Public Class Properties
    #region Public Properties
    public float Velocity
    {
        get
        {
            return velocity;
        }

        set
        {
            velocity = value;
        }
    }

    public float XPos
    {
        get
        {
            return xPos;
        }

        set
        {
            xPos = value;
        }
    }

    public float YPos
    {
        get
        {
            return yPos;
        }

        set
        {
            yPos = value;
        }
    }

    public float ZPos
    {
        get
        {
            return zPos;
        }

        set
        {
            zPos = value;
        }
    }
    #endregion
    
    public bool IsCollide(Block other, int blockNum)
    {
        float distanceBetween = this.XPos - other.XPos;
        Debug.Log(distanceBetween);
        if (distanceBetween >= 200)
        {
            //Debug.Log("Not Collide");
            return false;
        }
        else
        {
            //Debug.Log("Collide");
            return true;
        }
        
    }
    

    public bool HitWall()
    {
        if(this.XPos <= 0)
        {
            this.Velocity *= -1;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public float Bounce(Block other)
    {
        float sumM = this.mass + other.mass;
        float newV = (this.mass - other.mass) / sumM * this.Velocity;
        newV += (2 * other.mass / sumM) * other.Velocity;
        return newV;
    }
}
