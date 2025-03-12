using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour
{
    [SerializeField] private GameObject monsterSpawn;

    public GameObject spawnPoint;
    //public GameObject monsterList;

    

    void Start()
    {
        Debug.Log("Spawn");
        monsterSpawn.gameObject.SetActive(true);
        //FindMonster findMonster = GameObject.Instantiate<>
        Instantiate(monsterSpawn, spawnPoint.transform.position, Quaternion.identity);

        //MonsterCtrl.instance.StartCountdown();


    }

    void Update()
    {
        
    }
}
