using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour , IDropHandler
{

    public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
    public class OnItemDroppedEventArgs : EventArgs
    {
        public BrewItem item;
        public int x;
        public int y;
    }

    private int x;
    private int y;

    public void OnDrop(PointerEventData eventData)
    {
        Dragger_UI.Instance.Hide();
        BrewItem item = Dragger_UI.Instance.GetItem();
        OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item, x = x, y = y });
    }

    public void SetXY(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
