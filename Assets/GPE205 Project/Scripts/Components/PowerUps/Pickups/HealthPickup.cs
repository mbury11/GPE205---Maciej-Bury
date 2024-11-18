using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthPowerup powerup;
    public AudioClip pickUpAudio;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    // Initialize the audio source
        audioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(pickUpAudio, transform.position);
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null) 
        {
            // Add the powerup
            powerupManager.Add(powerup);

            // Destroy this pickup
            Destroy(gameObject);
        }
    }
}
