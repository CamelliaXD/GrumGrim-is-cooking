using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
    [SerializeField] private GameObject monsterSpawn;

    public GameObject spawnPoint;


    void Start()
    {
        Debug.Log("Spawn");
        Instantiate(monsterSpawn, spawnPoint.transform.position, Quaternion.identity);
            //(potionPrefab, new Vector2(), Quaternion.identity)
    }

    void Update()
    {
        
    }
}
