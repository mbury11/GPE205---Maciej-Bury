using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //variable for turn speed
    public float turnSpeed;
    
    //variable for movement speed
    public float moveSpeed;
    
    //variable to hold mover
    protected Mover mover;

    //variable for rate of fire
    public float fireRate;

    //variable for shots per second
    public float shotsPerSecond;

    //inverse shots per second
    float secondsPerShot;

    //hold the shooter function
    protected Shooter shooter;

    //variable for noisemaker
    public NoiseMaker noiseMaker;
    

    //variable for our shell prefab
    public GameObject shellPrefab;
    //variable for our firing force
    public float fireForce;
    //variable for damage done
    public float damageDone;
    //variable for how long our bullets survive if they don't collide
    public float shellLifespan;
    //variable for vol distance when moving
    public float movingVolumeDistance;

    // Start is called before the first frame update
    //added "virtual" after public because it can possibly be overridden
    public virtual void Start()
    {
    mover = GetComponent<Mover>();   
    secondsPerShot = 1 / shotsPerSecond;
    shooter = GetComponent<Shooter>();
    noiseMaker = GetComponent<NoiseMaker>();
    }

    // Update is called once per frame
    //added "virtual" after public because it can possibly be overridden
    public virtual void Update()
    {
        
    }
    //functions for movement
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
    
    /*public virtual void StopMovement()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }*/
}
