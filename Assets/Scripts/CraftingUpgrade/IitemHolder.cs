using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IitemHolder
{
    void RemoveItem(BrewItem item);
    void AddItem(BrewItem item);
    bool CanAddItem();
}
