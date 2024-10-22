using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameController : MonoBehaviour
{
    // Variable to hold the pawn
    public Pawn pawn;

    // Start is called before the first frame update
    public virtual void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    { 
    }
    //Child class MUST override the way they process inputs
    public abstract void ProcessInputs();
}
