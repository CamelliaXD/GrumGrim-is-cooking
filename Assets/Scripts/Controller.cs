using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour //, IPointerDownHandler , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    private SpriteRenderer spriteRenderer;
    private Materials currentMaterial;
    public Image pointer;

    public Slot[] craftingSlot;
    public List<Materials> materiallist;
    public string[] recipe;
    public Materials[] recipeResult;
    public Slot resultSlot;

    void Start()
    {
        //spriteRenderer = this.GetComponent<SpriteRenderer>();
        //addPhysics2DRaycast();
    }

    //void addPhysics2DRaycast()
    //{
    //    Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
    //    if (physicsRaycaster == null)
    //    {
    //        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
    //    }
    //}

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
    }

    void CheckRecipe()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.material = null;

        string currentRecipeString = "";
        foreach(Materials materials in materiallist)
        {
            if (materials != null)
            {
                currentRecipeString += materials.materialType;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for (int i=0; i<recipe.Length; i++)
        {
            if(recipe[i] == currentRecipeString)
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResult[i].GetComponent<Image>().sprite;
                resultSlot.material = recipeResult[i];
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


    //public void OnDrag(PointerEventData eventData)
    //{
    //    Debug.Log("OnDrag: ");
    //    //transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    //    //Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Debug.Log("End: ");
    //}
}
