using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public GameObject cameraPrefab;
    public GameObject aIControllerPrefab;
    public GameObject[] EnemiesArray;

    // Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;



    //player camera offsets
    public float cameraOffsetBack;
    public float cameraOffsetUp;
    
    // public Transform playerSpawnTransform;

    //reference to our map generator
    public MapGenerator mapGenerator;

    //list player controllers
    public List<PlayerController> players = new List<PlayerController>();
    
    //list ai controllers
    public List<AIController> enemies = new List<AIController>();

    //list of pawn spawn points
    public PawnSpawnPoint[] pawnSpawnPoints;


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
        mapGenerator.GenerateMap();
        SpawnPlayer();
        SpawnAITanks();
        DeactivateAllStates();
        ActivateTitleScreen();
    }

    

    public void SpawnPlayer()
    {
        Transform spawnPoint = null;
        
        //find spawnpoints by the type
        pawnSpawnPoints = FindObjectsByType<PawnSpawnPoint>(FindObjectsSortMode.None);
       
        
        if (pawnSpawnPoints.Length > 0)
        {
            //randomly select a spawnPoint
            spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;
        }

        if (spawnPoint != null)
        {
            //spawn the player controller at 0,0,0 with no rotation
            GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //spawn our pawn and connect it to our controller
            GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

            newPawnObj.AddComponent<NoiseMaker>();

            //spawn our camera behind the tank
            GameObject newCameraObj = Instantiate(cameraPrefab, spawnPoint.position + (Vector3.back * cameraOffsetBack) + (Vector3.up * cameraOffsetUp), spawnPoint.rotation) as GameObject;

            //get the player controller component and pawn component
            Controller newController = newPlayerObj.GetComponent<Controller>();
            Pawn newPawn = newPawnObj.GetComponent<Pawn>();

            //hook them up
            newController.pawn = newPawn;
            newCameraObj.transform.parent = newPawnObj.transform;
        }
    }

    public void SpawnAITanks()
{
    // Spawn AI Tanks
    Transform spawnPoint = null;

    // Find spawn points by the type
    pawnSpawnPoints = FindObjectsByType<PawnSpawnPoint>(FindObjectsSortMode.None);

    if (pawnSpawnPoints.Length > 0)
    {
        // Randomly select a spawnPoint
        spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;

        foreach (GameObject EnemyObject in EnemiesArray)
        {
            GameObject instantiatedEnemy = Instantiate(EnemyObject, spawnPoint.position, spawnPoint.rotation);
            AIController newAIController = instantiatedEnemy.GetComponent<AIController>();
            Pawn newEnemyPawn = instantiatedEnemy.GetComponent<Pawn>();

            if (newAIController != null && newEnemyPawn != null)
            {
                newAIController.pawn = newEnemyPawn;
            }

            // Select a new spawn point for the next enemy
            spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;
        }
    }
}


    private void DeactivateAllStates()
    {
        // Deactivate all Game States
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }
    
    public void ActivateTitleScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        TitleScreenStateObject.SetActive(true);
        // Does whatever needs to be done when the title screen starts.
    }

    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
    }
    
    public void ActivateGameplay()
    {
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
    }

    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
    }
}


