using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnPlayer();
        SpawnAITanks(); // Call to spawn AI Tanks
    }

    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject playerAIControllerPrefab;
    public GameObject tankAIPawnPrefab;

    public Transform playerSpawnTransform;
    public Transform computerSpawnTransform;

    public void SpawnPlayer()
    {
        if (playerControllerPrefab == null)
        {
            Debug.LogError("Player Controller Prefab is not assigned!");
            return;
        }

        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        Debug.Log("Player Controller instantiated successfully.");

        if (tankPawnPrefab == null)
        {
            Debug.LogError("Tank Pawn Prefab is not assigned!");
            return;
        }

        if (playerSpawnTransform == null)
        {
            Debug.LogError("Player Spawn Transform is not assigned!");
            return;
        }

        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        Debug.Log("Tank Pawn instantiated successfully.");

        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        if (newController == null || newPawn == null)
        {
            Debug.LogError("Failed to retrieve Controller or Pawn component.");
            return;
        }

        newController.pawn = newPawn;
    }

    public void SpawnAITanks()
    {
        if (playerAIControllerPrefab == null || tankAIPawnPrefab == null || computerSpawnTransform == null)
        {
            Debug.LogError("AI Prefabs or Spawn Transform are not assigned!");
            return;
        }

        for (int i = 0; i < 1; i++) // Spawning 1 AI Tanks
        {
            GameObject newAIController = Instantiate(playerAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject newAIPawn = Instantiate(tankAIPawnPrefab, computerSpawnTransform.position, computerSpawnTransform.rotation) as GameObject;

            Debug.Log("AI Tank instantiated successfully.");
            
        }
    }

    public List<PlayerController> players;
}
