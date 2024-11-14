using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveSpeedPowerUp : Powerup
{
    public float moveSpeedToAdd;

    public override void Apply(PowerupManager target)
    {
        // Retrieve the Pawn component from the target
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if (targetPawn != null) 
        {
            // Increase the Pawn's movement speed
            targetPawn.moveSpeed += moveSpeedToAdd; 
        }
    }
    
    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            // Decrease the Pawn's movement speed
            targetPawn.moveSpeed -= moveSpeedToAdd;
        }
    }
}
