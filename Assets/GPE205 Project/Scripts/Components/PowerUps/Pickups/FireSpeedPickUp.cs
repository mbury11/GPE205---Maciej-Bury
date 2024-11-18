using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeedPickUp : MonoBehaviour
{
    public FireSpeedPowerUp powerup;
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
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();
        if (powerupManager != null) 
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);      
        }
    }


}
/*if (audioSource != null && pickUpAudio != null)
            {
                audioSource.PlayClipAtPoint(pickUpAudio, transform.position); 
                if (audioSource.isPlaying)
                {}
            }*/