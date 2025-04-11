using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/RecipeObjectScript")]

public class RecipeScriptObject : ScriptableObject
{
    public ItemObjectScript result;

    public ItemObjectScript item_00;
    public ItemObjectScript item_10;

    public ItemObjectScript GetItem(int x, int y)
    {
        if (x == 0 && y == 0) return item_00;
        if (x == 1 && y == 0) return item_10;
        //if (x == 2 && y == 0) return item_20;

        //if (x == 0 && y == 1) return item_01;
        //if (x == 1 && y == 1) return item_11;
        //if (x == 2 && y == 1) return item_21;

        return null;
    }
}
