using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting_Ui : MonoBehaviour
{
    [SerializeField] private Transform ItemPf_UI;

    private Transform[,] slotTransformArray;
    private Transform outputSlotTransform;
    private Transform itemContainer;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        Transform gridContainer = transform.Find("Slots");
        itemContainer = transform.Find("BrewItem");

        slotTransformArray = new Transform[CraftingSystem.GRID_SIZE, CraftingSystem.GRID_SIZE];

        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                slotTransformArray[x, y] = gridContainer.Find("grid_" + x + "_" + y);
                ItemSlot craftingItemSlot = slotTransformArray[x, y].GetComponent<ItemSlot>();
                craftingItemSlot.SetXY(x, y);
                craftingItemSlot.OnItemDropped += Crafting_Ui_OnItemDropped;
            }
        }

        outputSlotTransform = transform.Find("ResultSlot");

        //CreateItem(0, 0, new Item { itemType = Item.ItemType.Diamond });
        //CreateItem(1, 2, new Item { itemType = Item.ItemType.Wood });
        //CreateItemOutput(new Item { itemType = Item.ItemType.Sword_Wood });
    }

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        craftingSystem.OnGridChanged += CraftingSystem_OnGridChanged;

        UpdateVisual();
    }

    private void CraftingSystem_OnGridChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void Crafting_Ui_OnItemDropped(object sender, ItemSlot.OnItemDroppedEventArgs e)
    {
        craftingSystem.TryAddItem(e.item, e.x, e.y);
    }

    private void UpdateVisual()
    {
        // Clear old items
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        // Cycle through grid and spawn items
        for (int x = 0; x < CraftingSystem.GRID_SIZE; x++)
        {
            for (int y = 0; y < CraftingSystem.GRID_SIZE; y++)
            {
                if (!craftingSystem.IsEmpty(x, y))
                {
                    CreateItem(x, y, craftingSystem.GetItem(x, y));
                }
            }
        }

        if (craftingSystem.GetOutputItem() != null)
        {
            CreateItemOutput(craftingSystem.GetOutputItem());
        }
    }

    private void CreateItem(int x, int y, BrewItem item)
    {
        Transform itemTransform = Instantiate(ItemPf_UI, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<ItemPrefab_UI3>().SetItem(item);
    }

    private void CreateItemOutput(BrewItem item)
    {
        Transform itemTransform = Instantiate(ItemPf_UI, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = outputSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.localScale = Vector3.one * 1.5f;
        itemTransform.GetComponent<ItemPrefab_UI3>().SetItem(item);
    }
}
