using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public float timerDelay = 5f;
    private float timeUntilNextEvent;
    private Transform tf; // A variable to hold our Transform component
    private Rigidbody rb; // Declare Rigidbody
    private Vector3 direction;
    public AudioClip cannonAudio;
    private AudioSource audioSource;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        timeUntilNextEvent = timerDelay;
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>(); // Initialize Rigidbody
        shooter = GetComponent<Shooter>();
        direction = tf.forward; // Now this will work correctly
        timeUntilNextEvent = Time.time + 1 / fireRate;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        timeUntilNextEvent -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (timeUntilNextEvent <= 0)
            {
                Shoot();
                timeUntilNextEvent = timerDelay; // reset the cooldown timer
            }
            else
            {
                Debug.Log("Shoot is on cooldown!");
            }
        }
    }

    public override void MoveForward()
    {
    // Ensure tf is assigned to the object's Transform
    direction = tf.forward; // Update direction based on current rotation
    Vector3 moveVector = direction * moveSpeed * Time.deltaTime; // Simplified calculation
    rb.MovePosition(rb.position + moveVector);
    Debug.Log("Move Forward");
    }

    public override void MoveBackward()
    {
    // Ensure tf is assigned to the object's Transform
    direction = -tf.forward; // Update direction for backward movement
    Vector3 moveVector = direction * moveSpeed * Time.deltaTime; // Simplified calculation
    rb.MovePosition(rb.position + moveVector);
    Debug.Log("Move Backward");
    }

    public override void RotateClockwise()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime); // Rotate clockwise
        Debug.Log("Rotate Clockwise");
    }

    public override void RotateCounterClockwise()
    {
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime); // Rotate counterclockwise
        Debug.Log("Rotate Counterclockwise");
    }

    // Implementing the Shoot method
    public override void Shoot()
    {
        
        if (Time.time >= timeUntilNextEvent)
        {shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
        timeUntilNextEvent = Time.time + 1 / fireRate;
        Debug.Log("Tank has shot!");
        }
        //play audio source
        if (audioSource != null && cannonAudio != null)
        {
            audioSource.PlayOneShot(cannonAudio);
        }
    } 

    //rotate towards function code
    public override void RotateTowards(Vector3 targetPosition)
    {
        //find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        //find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        //rotate closer to that vector but don't rotate more than our turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
