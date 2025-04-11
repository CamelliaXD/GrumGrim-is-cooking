using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PotionCheck : MonoBehaviour
{
    public static PotionCheck potionCheck;

    private SpriteRenderer spriteRenderer;
    /*private*/ public Materials currentPotion;
    public Image pointer;
    private Collider2D col;

    //public Materials[] craftingPotion;
    //public Sprite[] monsterSprite;

    public Slot[] conditionSlot;
    public Materials[] craftingPotion;
    public Sprite[] monsterSprite;
    public Sprite monster;
    public List<Materials> potionlist;
    public Slot[] dropPotionSlot;



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
        craftingPotion[randomNum] = currentPotion;
    }


    //void PotionCheck()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        //{
        //    if (currentPotion != null)
        //    {
        //        pointer.gameObject.SetActive(false);
        //        Slot nearestSlot = null;
        //        float shortestDistance = float.MaxValue;

        //        foreach (Slot slot in dropPotionSlot)
        //        {
        //            float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

        //            if (dist < shortestDistance)
        //            {
        //                shortestDistance = dist;
        //                nearestSlot = slot;
        //            }
        //        }

        //        nearestSlot.gameObject.SetActive(true);
        //        nearestSlot.GetComponent<Image>().sprite = currentPotion.GetComponent<Image>().sprite;
        //        nearestSlot.material = currentPotion;

        //        potionlist[nearestSlot.index] = currentPotion;
        //        currentPotion = null;
        //        CheckPotion();
        //    }
        //}
    }

    void CheckPotion()
    {
        Debug.Log("CheckPotion");
    }

    public void OnPointerDown(Materials materials)
    {

        //if (currentPotion == null)
        //{
        //    currentPotion = materials;
        //    pointer.gameObject.SetActive(true);
        //    pointer.sprite = currentPotion.GetComponent<Image>().sprite;
        //}

        //col.enabled = false;
        //Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        //col.enabled = true;
        //if (hitCollider != null && hitCollider.TryGetComponent(out Pointer pointer))
        //{
            
        //}

        //Debug.Log("PotionDrop");
        //slot.material = null;
        //potionlist[slot.index] = null;
        //slot.gameObject.SetActive(false);
        //CheckPotion();


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Potion collision");
        ////pointer.sprite = pointer.GetComponent<Image>().sprite;
        //pointer.sprite = pointer.GetComponent<Image>().sprite;
        //if (pointer.sprite != null)
        //{
        //    if (currentPotion.GetComponent<Image>().sprite.name == pointer.GetComponent<Image>().sprite.name)
        //    {
        //        Debug.Log("Potioncheck");
        //    }

        //    else
        //    {
        //        Debug.Log("Potion not match");
        //    }
        //}
    }
}
