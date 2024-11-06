using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightState : AIController
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
            case AIState.Chase:
                DoChaseState();
                if (CanHear(target))
                {
                    // Remain in Chase state
                }
                else if (CanSee(target))
                {
                    ChangeState(AIState.Shoot); // Transition to Shoot state
                }
                break;
            case AIState.Shoot:
                if (CanSee(target))
                {
                    DoShootState(); // Handle shooting
                }
                else
                {
                    ChangeState(AIState.Chase); // Transition back to Chase state
                }
                break;
        }
    }
}
