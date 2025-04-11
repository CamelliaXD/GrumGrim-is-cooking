using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour//, IPointerDownHandler , IBeginDragHandler 
{
    public static Controller instance;

    private SpriteRenderer spriteRenderer;
    private Materials currentMaterial;
    public Image pointer;

    //private BrewItem item;

    [SerializeField] private GameObject potionPrefab;

    public Slot[] craftingSlot;
    public List<Materials> materiallist;
    public string[] recipe;
    public Materials[] recipeResult;
    public Slot resultSlot;

    public Slider brewTimerSlider;
    public float maxbrewTimer = 0.10f;
    public float brewTimer;
    public bool stopTimer = false;
    public bool startBrewtime = false;

    public TMP_Text brewTimertext;

    //result
    public GameObject[] potionForResult;
    public GameObject spawnPotion;


    //public bool shouldLerp = false;
    //public float lerpSpeed = 0.05f;

    void Start()
    {

        //brewTimerSlider.maxValue = brewTimer;
        //brewTimerSlider.value = brewTimer;
        //StartTimer();
    }



    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(currentMaterial != null)
            {
                pointer.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue ;

                foreach (Slot slot in craftingSlot)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }

                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentMaterial.GetComponent<Image>().sprite;
                nearestSlot.material = currentMaterial;

                materiallist[nearestSlot.index] = currentMaterial;
                currentMaterial = null;
                CheckRecipe();
            }
        }
        brewTimerSlider.maxValue = maxbrewTimer;
        brewTimerSlider.value = brewTimer;
        brewTimertext.text = $"{ brewTimer} Sec";

        //Debug.Log("brewTimer : " + brewTimerSlider.value);
        //Debug.Log("maxbrewTimer " + maxbrewTimer);
        if (brewTimer >= maxbrewTimer)
        {
            //Debug.Log("Call Check");
            StopTimer();
            resultSlot.gameObject.SetActive(true);
            ClearCraftingSlot();
        }
    }

    public void StartTimer()
    {
        StartBrewTime();
        StartCoroutine(StartTimeTicker());
    }

    IEnumerator StartTimeTicker()
    {
        while (stopTimer == false)
        {
            brewTimer += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (brewTimer == maxbrewTimer)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                brewTimerSlider.value = brewTimer;
            }
        }


    }

    public void StopTimer()
    {
        startBrewtime = false;
        stopTimer = true;
        brewTimerSlider.value = 0f;
        brewTimer = 0f;
    }

    public void StartBrewTime()
    {
        startBrewtime = true;
        stopTimer = false;

    }

    //public void //Awake()
    //{
    //    brewTimertext.text = $"{ brewTimer} Sec.";
    //}

    void CheckRecipe()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.material = null;

        string currentRecipeString = "";
        foreach(Materials materials in materiallist)
        {
            Debug.Log("Meterial in slot :" + materiallist);
            Debug.Log("currentRecipeString :" + currentRecipeString);

            if (materials != null)
            {
                currentRecipeString += materials.materialType;
                Debug.Log("Start Brew");
                StartTimer();
                
            }


            else
            {

                currentRecipeString += "null";
                Debug.Log("Stop Brew");
                StopTimer();
            }

        }
            

        for (int i=0; i<recipe.Length; i++)
        {
            //Debug.Log("Active Forloop");
            //resultSlot.GetComponent<Image>().sprite = recipeResult[i].GetComponent<Image>().sprite;

            if (recipe[i] == currentRecipeString) 
            {
                //Debug.Log("Create Potion");

                resultSlot.GetComponent<Image>().sprite = recipeResult[i].GetComponent<Image>().sprite;
                resultSlot.material = recipeResult[i];

                //newMonInZone.transform.SetParent(monZone.transform, false);

                //Instantiate(potionPrefab, new Vector2(), Quaternion.identity);

            }
        }
    }


    public void OnClickSlot(Slot slot)
    {
        slot.material = null;
        materiallist[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckRecipe();
    }

    public void OnPointerDown(Materials materials)
    {
        //Debug.Log("clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (currentMaterial == null)
        {
            currentMaterial = materials;
            pointer.gameObject.SetActive(true);
            pointer.sprite = currentMaterial.GetComponent<Image>().sprite;
        }
    }

    public void OnClickResultSlot(Slot slot)
    {
        if (currentMaterial == null)
        {
            Debug.Log("clicked");
            //var currentMaterial = new currentPotion;
            pointer.gameObject.SetActive(true);
            pointer.sprite = slot.material.GetComponent<Image>().sprite;


            slot.gameObject.SetActive(false);

            //ClearCraftingSlot();
        }
    }

    public void ClearCraftingSlot()
    {
        Debug.Log("Clear ResultSlot");
        foreach (Slot slot in craftingSlot)
        {
            slot.material = null;
            materiallist[slot.index] = null;
            slot.gameObject.SetActive(false);
        }
    }


}
