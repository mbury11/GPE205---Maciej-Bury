using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownExample : MonoBehaviour
{
    public float timerDelay = 5f;
    private float timeUntilNextEvent;

    // Start is called before the first frame update
    void Start()
    {
    timeUntilNextEvent = timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
    timeUntilNextEvent -= Time.deltaTime;
    if (timeUntilNextEvent <= 0)
    {
        Debug.Log("It's the final countdown");
        timeUntilNextEvent = timerDelay;
    } 
    }
}
