using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExample : MonoBehaviour
{
    
    public string theText = "Hello World";
        // Use this for initialization
        private void Start()
        {
        // Write the value stored in our variable "theText" to the console window
        //Debug.Log(theText);   
        }

    // Start is called before the first frame update
    /* void Start()
    {

    }
*/
    // Update is called once per frame
    void Update()
    {
    Debug.Log(theText);   
    }
}

