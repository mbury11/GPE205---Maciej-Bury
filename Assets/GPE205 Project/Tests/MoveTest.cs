using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{   
    //float for the speed variable
    public float speed;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
    transform.position = transform.position + (Vector3.up * speed);
        
    }
}
