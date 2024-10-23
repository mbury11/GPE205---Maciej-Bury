using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Awake is called when the object is first created, before the Start even runs.
    private void Awake()
    {
        // If the instead doesn't exist
        if (instance == null)
        {
            instance = this;
            // Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Otherwise, there is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }
    }



    //Start is called before the first frame update
    void Start()
    {
        // temp code for now so SpawnPlayer() can function
    }
/* 
    // Update is called once per frame
    void Update()
    {
        
    } */

    // prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    //location of playerSpawnTransform
    public Transform playerSpawnTransform;
    
    public void SpawnPlayer()
    {
    //spawn the player controller at 0,0,0 with no rotation
    GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
    
    
    //Spawn the pawn and connect it to the controller
    GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
    
    //Get the Player Controller component and Pawn component.
    Controller newController = newPlayerObj.GetComponent<Controller>();
    Pawn newPawn = newPawnObj.GetComponent<Pawn>();
    
    //Hooked up gameobject with pawn
    newController.pawn = newPawn;
    }

    // List that holds our player(s)
    public List<PlayerController> players;
}
