using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public float timerDelay = 5f;
    private float timeUntilNextEvent;

    // Start is called before the first frame update
    public override void Start()
    {
    base.Start();

    timeUntilNextEvent = timerDelay;

    }

    // Update is called once per frame
    public override void Update()
    {
    base.Update();

    timeUntilNextEvent -= Time.deltaTime;

    if (Input.GetKeyDown(KeyCode.F))
    {
        if (timeUntilNextEvent <=0)
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
        //Debug.Log("Move Forward");
    }
    public override void MoveBackward()
    {
        //Debug.Log("Move Backward");
    }
    public override void RotateClockwise()
    {
        //Debug.Log("Move Clockwise");
    }
    public override void RotateCounterClockwise()
    {
        //Debug.Log("Move Counterclockwise");        
    }

    private void Shoot()
    {
        // implement shoot logic here
        Debug.Log("Tank has shot!");
    }
}
