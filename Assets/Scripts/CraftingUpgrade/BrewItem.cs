using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class BrewItem
{
    public enum ItemType
    {
        None,
        Herb,
        Bone,
        Crystal,

        RedPotion,
        BluePotion,
        GreenPotion,
    }

    public ItemObjectScript itemObjectScript;
    private IitemHolder itemHolder;

    public void SetItemHolder(IitemHolder itemHolder)
    {
        this.itemHolder = itemHolder;
    }

    public IitemHolder GetItemHolder()
    {
        return itemHolder;
    }

    public void RemoveFromItemHolder()
    {
        if (itemHolder != null)
        {
            // Remove from current Item Holder
            itemHolder.RemoveItem(this);
        }
    }

    public void MoveToAnotherItemHolder(IitemHolder newItemHolder)
    {
        RemoveFromItemHolder();
        // Add to new Item Holder
        newItemHolder.AddItem(this);
    }


    public Sprite GetSprite()
    {
        return itemObjectScript.itemSprite;
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Bone: return ItemAssets.Instance.boneSprite;
            case ItemType.Crystal: return ItemAssets.Instance.crystalSprite;
            case ItemType.Herb: return ItemAssets.Instance.herbSprite;

            case ItemType.RedPotion: return ItemAssets.Instance.redPotionSprite;
            case ItemType.GreenPotion: return ItemAssets.Instance.greenPotionSprite;
            case ItemType.BluePotion: return ItemAssets.Instance.bluePotionSprite;
        }                    
    }

    public override string ToString()
    {
        return itemObjectScript.itemName;  
    }


    //just in case
    //public Color GetColor()
    //{
    //    return Color.white;// GetColor(itemType);
    //}



}
