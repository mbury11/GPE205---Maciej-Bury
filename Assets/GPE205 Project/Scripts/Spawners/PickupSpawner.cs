using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;
    public GameObject[] pickUps;
    private Transform spawnPoint; // Assuming spawnPoint is defined somewhere
    public GameObject[] pawnSpawnPoints; // Assuming this is defined to hold spawn points

    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedPickup == null)
        {
            // If it is time to spawn a pickup
            if (Time.time > nextSpawnTime)
            {
                // Randomly select a pickup from the array
                GameObject randomPickup = pickUps[Random.Range(0, pickUps.Length)];
                // Spawn it and set the next time
                spawnedPickup = Instantiate(randomPickup, transform.position, Quaternion.identity);
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // postpone the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
