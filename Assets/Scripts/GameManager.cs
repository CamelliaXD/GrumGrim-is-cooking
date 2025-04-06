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
    public int playerStm;
    public int maxPlStm = 10;
    public Slider plStm_Slider;

    public int score;
    public int maxScore = 5;
    public TMP_Text MyScoreText;
    public TMP_Text RequiredScore;

    //monster
    public float moncurrentHp;
    public int monMaxHp = 30;
    public Slider monHp_Slider;

    /*private bool canSpawn = true;
    private bool canAnime = true;*/

    public Animator animator;

    //gameui gameover menu
    public GameObject gameOver;
    public GameObject gameWin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
