using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPowerup : Powerup
{
    public float healthToAdd;
    public override void Apply(PowerupManager target)
    {
        // Apply Health changes
        Health targetHealth = target.gameObject.GetComponent<Health>();
        if (targetHealth != null) 
        {
            // The second parameter is the pawn who caused the healing - in this case, they healed themselves
            targetHealth.Heal(healthToAdd, target.gameObject.GetComponent<Pawn>()); 
        }
    }
    
    public override void Remove(PowerupManager target)
    {
        Health targetHealth = target.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.gameObject.GetComponent<Pawn>());
        }
    }
}
