using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
{
    Health otherHealth = other.gameObject.GetComponent<Health>();
    if (otherHealth != null)
    {
        Debug.Log($"Attempting to deal {damageDone} damage to {other.gameObject.name}");
        otherHealth.TakeDamage(damageDone, owner);
        Debug.Log($"{other.gameObject.name} now has {otherHealth.currentHealth} health remaining.");
        
        // Correctly destroy the current GameObject (the projectile)
        Destroy(gameObject);
    }
    else
    {
        Debug.LogWarning($"{other.gameObject.name} does not have a Health component.");
    }
}



}

