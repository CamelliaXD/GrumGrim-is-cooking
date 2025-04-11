using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] private Transform ItemPf_UI;

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        itemSlotTemplate.gameObject.SetActive(false);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 54f;
        foreach (Inventory.InventorySlot inventorySlot in inventory.GetInventorySlotArray())
        {
            BrewItem item = inventorySlot.GetItem();

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            //itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                // Use item
                //inventory.UseItem(item);
            //};
            //itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {
            //    // Split item
            //    if (item.IsStackable())
            //    {
            //        // Is Stackable
            //        if (item.amount > 2)
            //        {
            //            // Can split
            //            int splitAmount = Mathf.FloorToInt(item.amount / 2f);
            //            item.amount -= splitAmount;
            //            Item duplicateItem = new Item { itemScriptableObject = item.itemScriptableObject, amount = splitAmount };
            //            inventory.AddItem(duplicateItem);
            //        }
            //    }

            //    // Drop item
            //    //Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            //    //inventory.RemoveItem(item);
            //    //ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            //};

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

            if (!inventorySlot.IsEmpty())
            {
                // Not Empty, has Item
                Transform uiItemTransform = Instantiate(ItemPf_UI, itemSlotContainer);
                uiItemTransform.GetComponent<RectTransform>().anchoredPosition = itemSlotRectTransform.anchoredPosition;
                ItemPrefab_UI3 uiItem = uiItemTransform.GetComponent<ItemPrefab_UI3>();
                uiItem.SetItem(item);
            }

            //Inventory.InventorySlot tmpInventorySlot = inventorySlot;

            //ItemSlot uiItemSlot = itemSlotRectTransform.GetComponent<ItemSlot>();
            //uiItemSlot.SetOnDropAction(() => {
            //    // Dropped on this UI Item Slot
            //    Item draggedItem = UI_ItemDrag.Instance.GetItem();
            //    draggedItem.RemoveFromItemHolder();
            //    inventory.AddItem(draggedItem, tmpInventorySlot);
            //});

            /*
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (inventorySlot.IsEmpty()) {
                // Empty
                uiText.SetText("");
            } else {
                if (item.amount > 1) {
                    uiText.SetText(item.amount.ToString());
                } else {
                    uiText.SetText("");
                }
            }
            */

            x++;
            int itemRowMax = 7;
            if (x >= itemRowMax)
            {
                x = 0;
                y++;
            }
        }
    }


}
