using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragger_UI : MonoBehaviour
{
    public static Dragger_UI Instance { get; private set; }

    private Canvas canvas;
    private RectTransform rectTransform;
    private RectTransform parentRectTransform;
    private CanvasGroup canvasGroup;
    private Image image;
    private BrewItem item;
    //private TextMeshProUGUI amountText;

    private void Awake()
    {
        Instance = this;

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        image = transform.Find("image").GetComponent<Image>();
        //amountText = transform.Find("amountText").GetComponent<TextMeshProUGUI>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();

        Hide();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }

    public BrewItem GetItem()
    {
        return item;
    }

    public void SetItem(BrewItem item)
    {
        this.item = item;
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    //public void SetAmountText(int amount)
    //{
    //    if (amount <= 1)
    //    {
    //        amountText.text = "";
    //    }
    //    else
    //    {
    //        // More than 1
    //        amountText.text = amount.ToString();
    //    }
    //}

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(BrewItem item)
    {
        gameObject.SetActive(true);

        SetItem(item);
        SetSprite(item.GetSprite());
        //SetAmountText(item.amount);
        UpdatePosition();
    }

}
