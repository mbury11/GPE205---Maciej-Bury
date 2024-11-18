using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public AudioClip damageAudio;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
    // Setting Health to max
    currentHealth = maxHealth;
    // Initialize the audio source
    audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount, Pawn source)
{
    currentHealth -= amount;
    Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name);
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    
    if (damageAudio != null) // Null check for damageAudio
    {
        audioSource.PlayOneShot(damageAudio); // Use the initialized audioSource
    }
    else
    {
        Debug.LogWarning("Damage audio clip is not assigned.");
    }
    
    if (currentHealth <= 0)
    {
        Die(source);
    }
}



    public void Heal (float amount, Pawn source)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    
    
    public void Die(Pawn source)
{
    Destroy(gameObject);
    Pawn pawnComponent = gameObject.GetComponent<Pawn>();
    if (pawnComponent != null)
    {
        int scoreToAdd = pawnComponent.rewardPoints;
        source.controller.AddToScore(scoreToAdd);
    }
}

}
