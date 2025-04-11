using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : IitemHolder
{

    public const int GRID_SIZE = 1;

    public event EventHandler OnGridChanged;

    private List<RecipeScriptObject> recipeScriptableObjectList;

    private BrewItem[,] itemArray; 
    private BrewItem outputItem;   

    public CraftingSystem(List<RecipeScriptObject> recipeScriptableObjectList)
    {
        this.recipeScriptableObjectList = recipeScriptableObjectList;

        itemArray = new BrewItem[GRID_SIZE, GRID_SIZE];
        /*
        recipeDictionary = new Dictionary<Item.ItemType, Item.ItemType[,]>();

        // Stick
        Item.ItemType[,] recipe = new Item.ItemType[GRID_SIZE, GRID_SIZE];
        recipe[0, 2] = Item.ItemType.None;     recipe[1, 2] = Item.ItemType.None;     recipe[2, 2] = Item.ItemType.None; 
        recipe[0, 1] = Item.ItemType.None;     recipe[1, 1] = Item.ItemType.Wood;     recipe[2, 1] = Item.ItemType.None; 
        recipe[0, 0] = Item.ItemType.None;     recipe[1, 0] = Item.ItemType.Wood;     recipe[2, 0] = Item.ItemType.None;
        recipeDictionary[Item.ItemType.Stick] = recipe;
        
        */
    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public BrewItem GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem(BrewItem item, int x, int y)
    {
        if (item != null)
        {
            item.RemoveFromItemHolder();
            item.SetItemHolder(this);
        }
        itemArray[x, y] = item;
        CreateOutput();
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    //public void IncreaseItemAmount(int x, int y)
    //{
    //    GetItem(x, y).amount++;
    //    OnGridChanged?.Invoke(this, EventArgs.Empty);
    //}

    public void DecreaseItemAmount(int x, int y)
    {
        if (GetItem(x, y) != null)
        {
            //GetItem(x, y).amount--;
            //if (GetItem(x, y).amount == 0)
            //{
                RemoveItem(x, y);
            //}
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(BrewItem item, int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
            return true;
        }
        else
        {
            if (item.itemObjectScript == GetItem(x, y).itemObjectScript)
            {
                //IncreaseItemAmount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void RemoveItem(BrewItem item)
    {
        if (item == outputItem)
        {
            // Removed output item
            ConsumeRecipeItems();
            CreateOutput();
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // Removed item from grid
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (GetItem(x, y) == item)
                    {
                        // Removed this one
                        RemoveItem(x, y);
                    }
                }
            }
        }
    }

    public void AddItem(BrewItem item) { }

    public bool CanAddItem() { return false; }


    private ItemObjectScript GetRecipeOutput()
    {
        foreach (RecipeScriptObject recipeScriptObject in recipeScriptableObjectList)
        {

            bool completeRecipe = true;
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (recipeScriptObject.GetItem(x, y) != null)
                    {
                        // Recipe has Item in this position
                        if (IsEmpty(x, y) || GetItem(x, y).itemObjectScript != recipeScriptObject.GetItem(x, y))
                        {
                            // Empty position or different itemType
                            completeRecipe = false;
                        }
                    }
                }
            }

            if (completeRecipe)
            {
                return recipeScriptObject.result;
            }
        }
        return null;
    }

    private void CreateOutput()
    {
        ItemObjectScript recipeOutput = GetRecipeOutput();
        if (recipeOutput == null)
        {
            outputItem = null;
        }
        else
        {
            outputItem = new BrewItem { itemObjectScript = recipeOutput };
            outputItem.SetItemHolder(this);
        }
    }

    public BrewItem GetOutputItem()
    {
        return outputItem;
    }

    public void ConsumeRecipeItems()
    {
        for (int x = 0; x < GRID_SIZE; x++)
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                DecreaseItemAmount(x, y);
            }
        }
    }

}