using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionCheck : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Materials currentMaterial;
    public Image pointer;

    //public Materials[] craftingPotion;
    //public Sprite[] monsterSprite;

    public Slot[] conditionSlot;
    public Materials[] craftingPotion;
    public Sprite[] monsterSprite;
    public Object monster;

    //List<Materials> list;

    void Start()
    {
        RandomCondition();
    }

    public void RandomCondition()
    {
        Debug.Log("Random");
        var randomNum = Random.Range(0, 2);
        conditionSlot[0].GetComponent<Image>().sprite = craftingPotion[randomNum].GetComponent<Image>().sprite;
        conditionSlot[0].gameObject.SetActive(true);
    }


    //void PotionCheck()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
