using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Controller : MonoBehaviour
{
    // Variable to hold the pawn
    public Pawn pawn;

    public int score = 0;
    public int lives = 3;

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

    public abstract void AddToScore(int scoreToAdd);
    public abstract void RemoveFromScore(int scoreToRemove);
    public abstract void AddToLives(int livesToAdd);
    public abstract void RemoveFromLives(int livesToRemove);
}
