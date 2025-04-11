using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform ItemToCompare;

    public Sprite boneSprite;
    public Sprite herbSprite;
    public Sprite crystalSprite;

    public Sprite redPotionSprite;
    public Sprite bluePotionSprite;
    public Sprite greenPotionSprite;
}
