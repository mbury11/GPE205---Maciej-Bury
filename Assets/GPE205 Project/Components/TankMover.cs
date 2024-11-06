using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rb;
    private Transform tf;

    // Start is called before the first frame update
    public override void Start()
    {
    rb = GetComponent<Rigidbody>();
    tf = transform;
    }
    
    // Update is called once per frame
    public override void Update()
    {
    }
    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }
    public override void Rotate(float turnSpeed)
    {
        tf.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
    
}
