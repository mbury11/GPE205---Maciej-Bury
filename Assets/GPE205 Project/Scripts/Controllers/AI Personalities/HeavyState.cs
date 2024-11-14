using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HeavyState : AIController
{
    
    // Start is called before the first frame update
    public override void Start()
    {
    base.Start(); 
    }

    // Update is called once per frame
    public override void Update()
    {
    base.Update();    
    }
    public override void MakeDecisions()
{
    switch (currentState)  
    {
        case AIState.Patrol:
            DoPatrolState();
            if (CanHear(target))
            {
                ChangeState(AIState.Shoot); // Transition to Shoot state
            }
            else if (CanSee(target))
            {
                ChangeState(AIState.Shoot); // Transition to Shoot state
            }
            break;
        case AIState.Shoot:
            if (CanSee(target))
            {
                DoShootState(); // Assuming a method to handle shooting
            }
            else
            {
                ChangeState(AIState.Patrol); // Transition back to Patrol state if target is not visible
            }
            break;
    }
}
}