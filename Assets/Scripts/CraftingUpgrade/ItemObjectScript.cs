using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemObjectScript")]

public class ItemObjectScript : ScriptableObject
{

    public BrewItem.ItemType itemType;
    public string itemName;
    public Sprite itemSprite;

}
