using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject prefab;
    public Transform firepointTransform; //declaring firepoint transform
    
    
    // Start is called before the first frame update
    public override void Start()
    {
        
        GameObject newObject = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        Debug.Log(newObject.name);
    }

    // Update is called once per frame
    public override void Update()
    {
    }
    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float shellLifespan)
    {
        //instantiate our projectile
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        
        
        
        //get the damageonhit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();
        //if it has one..
        if (doh != null)
        {
            //... set the damageDone in the DamageOnHit component to the value passed in
            doh.damageDone = damageDone;
            //... set the owner to the pawn that shot this shell, if there is one (otherwise owner is null).
            doh.owner = GetComponent<Pawn>();
        }
        //get the rigidbody comp
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        //if it has one
        if (rb != null)
        {
            //...add force to make it move forward
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        //Destroy it after a set time
        Destroy (newShell, shellLifespan);
    }
}
