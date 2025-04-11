using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    //player
    public static int curPlayerStm;
    public int maxPlStm = 3;
    public Slider plStm_Slider;

    public int score = 0;
    public int maxScore = 5;
    public static int myCurScore ;
    public Text RequiredScoreText;

    //monster
    //private float speed = 2.0f;

    
    //private GameObject monInQueue;
    
    //spawn monster
    [SerializeField] private GameObject[] monsterPrefabs;
    public float spawnRate = 15.0f;
    public float spawnRate2 = 30.0f;
    public GameObject monZone;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    private bool canSpawn = true;
    private bool canSpawn2 = true;

    //queue
    // [SerializeField] private GameObject checkPosition;
    [SerializeField] private List<GameObject> queuePositionslist;
    [SerializeField] private List<MonsterCtrl> monToQueuelist;

    /*private bool canSpawn = true;
    private bool canAnime = true;*/

    //public Animator animator;

    //gameui gameover menu
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWin;


    // Start is called before the first frame update
    void Start()
    {
        plStm_Slider.maxValue = maxPlStm;
        plStm_Slider.value = maxPlStm;
        curPlayerStm = maxPlStm;
        //RequiredScoreText.text = $"{score}" + " "+"/"+" " + $"{maxScore}";
        RequiredScoreText.text = score + " / " + maxScore; 
        myCurScore = score;

        //first mon
        int rand = Random.Range(0, monsterPrefabs.Length);
        GameObject newMonInZone = Instantiate(monsterPrefabs[rand], new Vector3(0, 0, 0), Quaternion.identity);
        newMonInZone.transform.SetParent(monZone.transform, false);
        newMonInZone.transform.position = spawnPoint.transform.position;

        StartCoroutine(startSpawn());
        StartCoroutine(startSpawn2());
        //monToQueuelist.Add(newMonInZone);  //add to queue
    }

    // Update is called once per frame
    void Update()
    {
        plStm_Slider.value = curPlayerStm;
        RequiredScoreText.text = $"{myCurScore}" + "/" + $"{maxScore}";
    }

    public IEnumerator startSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        

        while (canSpawn)
        {
            yield return wait;
            //randomMonster
            int rand = Random.Range(0, monsterPrefabs.Length);
            //GameObject monInZone = monsterPrefabs[rand];

            //Set Parent 
            GameObject newMonInZone = Instantiate(monsterPrefabs[rand], new Vector3(0, 0, 0), Quaternion.identity);
            newMonInZone.transform.SetParent(monZone.transform, false);
            newMonInZone.transform.position = spawnPoint.transform.position;

            //Debug.Log("monster random");
        }

    }

    public IEnumerator startSpawn2()
    {
        WaitForSeconds waitForAnother = new WaitForSeconds(spawnRate2);
        while (canSpawn2)
        {
            yield return waitForAnother;
            //randomMonster
            int rand = Random.Range(0, monsterPrefabs.Length);
            //GameObject monInZone = monsterPrefabs[rand];

            //Set Parent 
            GameObject newMonInZone2 = Instantiate(monsterPrefabs[rand], new Vector3(0, 0, 0), Quaternion.identity);
            newMonInZone2.transform.SetParent(monZone.transform, false);
            newMonInZone2.transform.position = spawnPoint2.transform.position;

            //Debug.Log("monster random");
        }

    }

    //public void waitingQueue(List<GameObject> queuePositionslist)
    //{
    //    this.queuePositionslist = queuePositionslist;
    //    checkPosition = queuePositionslist[queuePositionslist.Count - 1];
    //    monToQueuelist = new List<MonsterCtrl>();
    //}

    //public bool canAddMonToQueue()
    //{
    //    return monToQueuelist.Count < queuePositionslist.Count;
    //}

    //public void addMonInQueue(MonsterCtrl monInQueue)
    //{
    //    float step = speed * Time.deltaTime;
    //    monToQueuelist.Add(monInQueue);
    //    //monInQueue.transform.position = Vector2.MoveTowards(transform.position, checkPosition.transform.position,step);
    //    monInQueue.transform.position = Vector2.MoveTowards(transform.position, checkPosition.transform.position, step);

    //}

}
