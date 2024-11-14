using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FireSpeedPowerUp : Powerup
{
    public float fireForceToAdd;
    public new float powerUpDuration = 30f; // Duration for the power-up effect
    private float originalFireForce; // Variable to store the original fire force

    public override void Apply(PowerupManager target)
    {
        Pawn pawn = target.GetComponent<Pawn>();
        if (pawn != null)
        {
            // Store the original fire force before applying the power-up
            originalFireForce = pawn.fireForce;
            pawn.fireForce += fireForceToAdd; // Increase the fire speed
            target.StartCoroutine(RemoveAfterDuration(target, powerUpDuration)); // Schedule removal
        }
    }

    public override void Remove(PowerupManager target)
    {
        Pawn pawn = target.GetComponent<Pawn>();
        if (pawn != null)
        {
            // Revert to the original fire speed
            pawn.fireForce = originalFireForce; 
        }
    }

    private IEnumerator RemoveAfterDuration(PowerupManager target, float powerUpDuration)
    {
        yield return new WaitForSeconds(powerUpDuration);
        Remove(target);
    }
}
