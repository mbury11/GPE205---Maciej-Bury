using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rb;
    // Start is called before the first frame update
    public override void Start()
    {
    rb = GetComponent<Rigidbody>();
    
    }
    // Update is called once per frame
    public override void Move(Vector3 direction, float speed)
    {
    Vector3 moveVector = transform.TransformDirection(direction.normalized) * speed * Time.deltaTime;
    rb.MovePosition(rb.position + moveVector);
    }
    public override void Rotate(Vector3 axis, float angle)
    {
    Quaternion rotation = Quaternion.Euler(axis * angle * Time.deltaTime);
    rb.MoveRotation(rb.rotation * rotation);
    }
    public override void Update()
    {
        Vector3 rotationAxis = new Vector3(0, 1, 0); //rotate on Y-axis
        float rotationSpeed = 30f; //Degrees per secon
        float angle = rotationSpeed * Time.deltaTime; // angle based on speed and time
        Rotate(rotationAxis, angle);
    }

}
