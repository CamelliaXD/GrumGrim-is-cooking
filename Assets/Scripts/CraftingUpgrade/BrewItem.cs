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
    //private IItemHolder = itemHolder;

    //public void SetItemHolder(IItemHolder itemHolder)
    //{
    //    this.ItemHolder = itemHolder;
    //}

    //public IItemHolder GetItemHolder()
    //{
    //    return itemHolder();
    //}

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
        return itemObjectScript.itemName;  //itemType.ToString();
    }



}
