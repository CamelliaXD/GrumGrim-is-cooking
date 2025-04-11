using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Potionctrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{

    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private Vector3 formerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addPhysics2DRaycast()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("potion PointerDown");
        formerPosition = transform.position;
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);


    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("potion OnDrag");
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("potion EndDrag");
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider == null )
        {
            transform.position = formerPosition;
        }

    }

}
