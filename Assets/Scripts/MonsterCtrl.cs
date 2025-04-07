using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MonsterCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public static MonsterCtrl instance;

    //public float moncurrentHp;
    public float monMaxHp = 30.0f;
    public Slider monHp_Slider;
    public bool stopCount = false;


    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private Vector3 formerPosition;
    [SerializeField] private GameObject deadSprite;

    public bool canCheckIn = true;

    public float countTimer;
    public float speed = 2.0f;
    //public GameObject checkPosition;

    public Canvas statPanel;
    //public GameObject monZone;


    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        addPhysics2DRaycast();

        monHp_Slider.maxValue = monMaxHp;
        monHp_Slider.value = monMaxHp;

        StartCoroutine(StartCountdown());
        stopGoToPostion();

    }

    private IEnumerator StartCountdown()
    {
        while (stopCount == false)
        {
            monMaxHp -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            
            if (monMaxHp <= 0)
            {
                stopCount = true;
                
                //Debug.Log("monster" + this.name +"died");
            }
            if (stopCount == false)
            {
                monHp_Slider.value = monMaxHp;
            }
        }

    }

    public void StopCount()
    {
        Debug.Log("died");
        stopCount = true;
        Destroy(gameObject);
    }

    void addPhysics2DRaycast()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    void Awake()
    {
        canCheckIn = true;
    }

    void Update()
    {
        //move to queue
        //while(canCheckIn == true)
        //{
        //    GameObject checkPosition = GameObject.Find("Queue2");
        //    this.transform.position = Vector2.MoveTowards(transform.position, checkPosition.transform.position, speed * Time.deltaTime);
        //    Debug.Log("moveto" + checkPosition.name);

        //}
        /*GameObject checkPosition = GameObject.Find("Queue2");*/
        //this.transform.position = Vector2.MoveTowards(transform.position, checkPosition.transform.position, speed * Time.deltaTime);
        //Debug.Log("moveto" + checkPosition.name);

        /*if(this.transform.position != checkPosition.transform.position)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, checkPosition.transform.position, speed * Time.deltaTime);
            Debug.Log("moveto" + checkPosition.name);
            //stopGoToPostion();
        }

        else
        {
            stopGoToPostion();
        }*/

    }

    public void stopGoToPostion()
    {
        canCheckIn = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        formerPosition = transform.position;
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        statPanel.gameObject.SetActive(false); //disactive canvas

        stopGoToPostion();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        stopGoToPostion();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out IHealDropZone healDropZone))
        {
            healDropZone.OnMonsDroptoZone(this, statPanel);

            stopGoToPostion();
        }
        else
        {
            transform.position = formerPosition;
            
        }

        statPanel.gameObject.SetActive(true); //active canvas

    }

}
