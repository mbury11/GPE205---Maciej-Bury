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
    public override void Update()
    {
        /* Vector3 rotationAxis = new Vector3(0, 1, 0); //rotate on Y-axis
        float rotationSpeed = 30f; //Degrees per secon
        float angle = rotationSpeed * Time.deltaTime; // angle based on speed and time
        Rotate(rotationAxis, angle);

        //to capture user inputs for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //call move with input
        Move(movement, 5f); */

        //capture user input for rotation
        float rotateHorizontal = Input.GetAxis("Horizontal"); //horizontal input in regards to rotation
        float rotationSpeed = 360f; //degrees per second
        float angle = rotateHorizontal * rotationSpeed * Time.deltaTime; //angle based on input and speed

        //rotate tank based on user inputs
        Rotate(Vector3.up, angle); //rotate around the y axis based on input

        // capture user input for movement
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical); //only forward and backward movements

        Move(movement, 5f); //assuming speed of 5 per second
    }
    
    //Move function is called
    public override void Move(Vector3 direction, float speed)
    {
    Vector3 moveVector = transform.TransformDirection(direction.normalized) * speed * Time.deltaTime;
    rb.MovePosition(rb.position + moveVector);
    }
    
    //Rotate function is called
    public override void Rotate(Vector3 axis, float angle)
    {
    Quaternion rotation = Quaternion.Euler(axis * angle);
    rb.MoveRotation(rb.rotation * rotation);
    }
}
