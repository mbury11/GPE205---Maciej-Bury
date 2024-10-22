using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    //public float turnSpeed = 50f;
    //variable for turning speed
 
    public abstract void Start();
    public abstract void Update();
    public abstract void Move(Vector3 direction, float speed);
    public abstract void Rotate(Vector3 axis, float angle);

}


