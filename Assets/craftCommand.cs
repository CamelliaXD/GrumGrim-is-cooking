//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class craftCommand : MonoBehaviour
//{
//    public GameObject player;
//    [SerializeField] private UI_Inventory uiInventory;

//    [SerializeField] private Crafting_Ui uiCraftingSystem;

//    [SerializeField] private StartingItem[] startingItemArray;
//    [SerializeField] private List<RecipeScriptObject> recipeScriptableObjectList;

//    [System.Serializable]
//    public struct StartingItem
//    {
//        public ItemObjectScript itemScriptableObject;
//        //public int amount;
//    }

//    private void Start()
//    {
        
//        uiInventory.SetInventory(player.GetInventory());

//        Inventory playerInventory = player.GetInventory();

//        foreach (StartingItem startingItem in startingItemArray)
//        {
//            playerInventory.AddItem(
//                new Item
//                {
//                    itemScriptableObject = startingItem.itemScriptableObject,
//                    amount = startingItem.amount
//                }
//            );
//        }

//        uiCharacterEquipment.SetCharacterEquipment(characterEquipment);

//        CraftingSystem craftingSystem = new CraftingSystem(recipeScriptableObjectList);
//        uiCraftingSystem.SetCraftingSystem(craftingSystem);
//    }

//}
