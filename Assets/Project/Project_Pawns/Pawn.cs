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
    public Mover mover;

    // Start is called before the first frame update
    //added "virtual" after public because it can possibly be overridden
    public virtual void Start()
    {
    mover = GetComponent<Mover>();   
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
}
