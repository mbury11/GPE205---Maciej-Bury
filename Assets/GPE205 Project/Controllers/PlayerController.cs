using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    
    // Start is called before the first frame update
    public override void Start()
    {
    //if we have a GameManager
    if (GameManager.instance != null)
    {
        //and it tracks the player(s)
        if (GameManager.instance.players != null)
        {
            // register with the GameManager
            GameManager.instance.players.Add(this);
        }
    }
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

    public void OnDestroy()
    {
        //if we have a GameManager
        if(GameManager.instance != null)
        {
            //and it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                //deregister with GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }
}
