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
    //public GameObject bossControllerPrefab;
    //public GameObject evaderControllerPrefab;
    //public GameObject heavyControllerPrefab;
    //public GameObject lightControllerPrefab;
    public GameObject[] EnemiesArray;

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
            //spawn AI Tanks
            Transform spawnPoint = null;
        
            //find spawnpoints by the type
            pawnSpawnPoints = FindObjectsByType<PawnSpawnPoint>(FindObjectsSortMode.None);
       
        
            if (pawnSpawnPoints.Length > 0)
                {
                    //randomly select a spawnPoint
                    spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;
                }
            foreach (GameObject EnemyObject in EnemiesArray)
            {
                Instantiate(EnemyObject, spawnPoint.position, spawnPoint.rotation);
                spawnPoint = pawnSpawnPoints[Random.Range(0, pawnSpawnPoints.Length)].transform;
            }
        }

}


