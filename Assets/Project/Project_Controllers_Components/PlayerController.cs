using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameController
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    
    // Start is called before the first frame update
    public override void Start()
    {
    // Run the start() function from the parent (base) Class
    base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
    //Process keyboard inputs
    ProcessInputs();

    //Run the Update() function from the parent (base) Class
    base.Update();
    }
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
    }
}
