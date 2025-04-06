using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MonsterCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public static MonsterCtrl instance;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private Vector3 formerPosition;

    //public Slider countdownSlider;
    //public float maxTimer = 0.10f;
    //public float coutingTime;
    //public bool stopCount = false;
    //public bool startCountTime = false;

    //public TMP_Text countdowntext;



    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        addPhysics2DRaycast();
    }

    void addPhysics2DRaycast()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        formerPosition = transform.position;
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out IHealDropZone healDropZone))
        {
            healDropZone.OnMonsDroptoZone(this);
        }
        else
        {
            transform.position = formerPosition;
        }

    }

    //public void StartCountdown()
    //{
    //    Debug.Log("StartCountdown");
    //    //coutingTime -= Time.deltaTime;
    //}
}
