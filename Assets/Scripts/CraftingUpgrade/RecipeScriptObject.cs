using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/RecipeObjectScript")]

public class RecipeScriptObject : ScriptableObject
{
    public ItemObjectScript result;

    public ItemObjectScript item_Left;
    public ItemObjectScript item_Right;

}
