using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Chase, 
    Flee, 
    Patrol, 
    ChooseTarget,
    Idle,
    Nearest,
    Shoot
}


public class AIController : Controller
{    
    //calling other classes
    private TankShooter tankShooter;
    protected Shooter shooter;
    private Rigidbody rb;

    //Declaring Variables
    public GameObject shellPrefab;
    public GameObject target;
    private float lastStateChangeTime;
    public AIState currentState;
    public float fleeDistance;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    public float hearingDistance;
    public float fieldOfView; // Declare FoV
   
    
    
    
    // Start is called before the first frame update
    public override void Start()
    {
    // run the parent base start
    base.Start(); 
    tankShooter = GetComponent<TankShooter>();
    ChangeState(currentState);
    shooter = GetComponent<Shooter>();
    rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
    // run the parent base update
    base.Update();
    MakeDecisions(); //to ensure decisions are made every frame
    }

    public override void ProcessInputs()
    {
    }




                            //STATE'S
    public virtual void ChangeState(AIState newState)
    {
        currentState = newState; // Update the current state
        lastStateChangeTime = Time.time; // Optionally track when the state changed
    }

    protected void DoIdleState()
    {
        // Do Nothing
    }
    
    public void DoSeekState()
    {
        // Seek our target
        Seek(target);
    }

    protected virtual void DoChaseState()
    {
        Seek(target);
    }

    protected virtual void DoPatrolState()
    {
        Patrol();
    }

    protected virtual void DoFleeState()
    {
        Flee();
    }

    protected virtual void DoNearestState()
    {
        TargetNearestTank();
    }

    protected virtual void DoAttackState()
    {
    // Chase
    Seek(target.transform);
    //tell pawn to shoot
    Shoot();
    }
    protected virtual void DoShootState()
    {
    Search(target.transform.position);
    //tell pawn to shoot
    Shoot();
    }




                            //END STATE'S

                            
                            //FUNCTIONS'S



    public void Seek(Vector3 targetPosition)
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(targetPosition);
        // Move Forward
        pawn.MoveForward();
    }

    public void Search(Vector3 targetPosition)
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(targetPosition); 
    }

    public void Seek(Transform targetTransform)
    {
        // Seek the position of our target Transform
        Seek(targetTransform.position);

        // RotateTowards the Funciton
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }
    
    public void Seek (GameObject target)
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }

    public void Seek(Pawn targetPawn)
    {
        // Seek the pawn's transform!
        Seek(targetPawn.transform);

        // RotateTowards the Funciton
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }

    public void Seek(Controller targetController)
    {
        Seek(targetController.transform);

        // RotateTowards the Funciton
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }

    protected void Shoot()
    {
        //tell the pawn to shoot
        pawn.Shoot();
    }


    protected void Flee()
    {
    // Find the Vector to our target
    Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
    // Calculate the distance to the target
    float targetDistance = vectorToTarget.magnitude;
    // Determine the percentage of fleeDistance based on targetDistance
    float percentOfFleeDistance = targetDistance / fleeDistance;
    // Clamp the percentage to ensure it remains between 0 and 1
    percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
    // Invert the percentage to determine the actual flee distance
    float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
    // Ensure a minimum flee distance of 1 unit
    float actualFleeDistance = Mathf.Max(flippedPercentOfFleeDistance * fleeDistance, 1f);
    // Find the Vector away from our target
    Vector3 vectorAwayFromTarget = -vectorToTarget.normalized;
    // Calculate the flee vector
    Vector3 fleeVector = vectorAwayFromTarget * actualFleeDistance;
    // Seek the point that is "fleeVector" away from our current position
    Seek(pawn.transform.position + fleeVector);
    }


    protected void Patrol()
{
    if (waypoints == null || waypoints.Length == 0)
    {
        Debug.LogError("Waypoints array is null or empty.");
        return; // Exit the method if there are no waypoints
    }

    // Declare distanceToWaypoint outside of the conditional blocks
    float distanceToWaypoint = Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position);

    // If we have enough waypoints in our list to move to a current waypoint
    if (currentWaypoint < waypoints.Length) 
    {
        // If we are close enough, then increment to next waypoint
        if (distanceToWaypoint <= waypointStopDistance) 
        {
            currentWaypoint++;
            Debug.Log($"Moving to next waypoint: {currentWaypoint}");
        }
        
        // Ensure currentWaypoint wraps around using modulo only if it exceeds the length
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0; // Reset to the first waypoint
        }
        
        // Then seek that waypoint
        Seek(waypoints[currentWaypoint]); 
        
        // Log the current position and distance to the waypoint for debugging
        Debug.Log($"Current Position: {pawn.transform.position}, Distance to Waypoint: {distanceToWaypoint}");
    } 
}








    protected void RestartPatrol()
    {
        // Set the index to 0
        currentWaypoint = 0;
    }


    public void TargetPlayerOne()
    {
        // If the GameManager exists
        if (GameManager.instance != null) 
        {
            // And the array of players exists
            if (GameManager.instance.players != null) 
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0) 
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }


    protected void TargetNearestTank()
    {
    // Get a list of all the tanks (pawns)
    Pawn[] allTanks = FindObjectsOfType<Pawn>();

    // Assume that the first tank is closest
    Pawn closestTank = allTanks[0];
    float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

    // Iterate through them one at a time
    foreach (Pawn tank in allTanks) {
        // If this one is closer than the closest
        if (Vector3.Distance(pawn.transform.position, tank.transform.position) < closestTankDistance) 
        {
            // It is the closest
            closestTank = tank;
            closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
        } 
    }

    // Target the closest tank
    target = closestTank.gameObject;
    }

                            
                            
                            //END FUNCTION'S




    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance ) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    protected bool IsDistanceGreaterThan(GameObject target, float distance)
    {
        if (Vector3.Distance (pawn.transform.position, target.transform.position) > distance ) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return (target != null);
    }

    public bool CanHear(GameObject target)
    {
        // Get the target's NoiseMaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If they don't have one, they can't make noise, so return false
        if (noiseMaker == null) 
        {
            return false;
        }
        // If they are making 0 noise, they also can't be heard
        if (noiseMaker.volumeDistance <= 0) 
        {
            return false;
        }
        // If they are making noise, add the volumeDistance in the noisemaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If the distance between our pawn and target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance) 
        {
            // ... then we can hear the target
            return true;
        }
        else 
        {
            // Otherwise, we are too far away to hear them
            return false;
        }
    }

    public bool CanSee(GameObject target)
{
    // Find the vector from the agent to the target
    Vector3 agentToTargetVector = target.transform.position - transform.position;
    
    // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
    float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
    
    // Check if the angle is within the field of view
    if (angleToTarget < fieldOfView) 
    {
        // Perform a raycast to check for obstructions
        //RaycastHit hit = Physics.Raycast(transform.position, agentToTargetVector.normalized, Mathf.Infinity);
        RaycastHit hit;

        if (Physics.Raycast(pawn.transform.position + Vector3.up/2.0f, agentToTargetVector.normalized, out hit))
        {
            if (hit.collider.gameObject == target)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
        
    }
    
    // If the angle is outside the field of view or the target is obstructed, return false
    return false;
}

                            
                            
                                
                                
                                //DECISIONS




    public virtual void MakeDecisions()
    {
    switch (currentState)  
    {
        case AIState.Idle:
            DoIdleState();
            if (CanHear(target))
            {
                ChangeState(AIState.Chase);
            }
            if (CanSee(target))
            {
                ChangeState(AIState.Chase);
            }
            break;
        case AIState.Chase:
            DoChaseState();
            if (!CanHear(target))
            {
                ChangeState(AIState.Idle);
            }
            if (!CanSee(target))
            {
                ChangeState(AIState.Idle);
            }
            break;
        case AIState.Patrol:
            DoPatrolState();
            if (IsDistanceLessThan(target, 10)) {
                ChangeState(AIState.Patrol); // Transition to Chase if the target is close
            }
            break;
        case AIState.Flee:
            DoFleeState();
            if (IsDistanceGreaterThan(target, 15)) {
                ChangeState(AIState.Idle); // Transition to Idle if the target is too far
            }
            break;
        case AIState.ChooseTarget:
            DoAttackState();
            if (IsDistanceLessThan(target, 15)) {
                ChangeState(AIState.ChooseTarget); // Transition to Chase if the target is close
            }
            else if (IsDistanceGreaterThan(target, 10)) {
                ChangeState(AIState.Idle); // Transition to Idle if the target is too far
            }
            break;
        case AIState.Nearest:
            DoNearestState();
            if (IsDistanceLessThan(target, 5)) {
            ChangeState(AIState.Chase); // Transition to Chase if the target is close
            }
            else if (IsDistanceGreaterThan(target, 10)) {
            ChangeState(AIState.Idle); // Transition to Idle if the target is too far
            }
            break;
    }
    }


                            //END DECISIONS

                            



  
}
