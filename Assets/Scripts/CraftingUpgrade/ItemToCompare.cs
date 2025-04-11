using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToCompare : MonoBehaviour
{
    public static ItemToCompare SpawnItemWorld(Vector3 position, BrewItem item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.ItemToCompare, position, Quaternion.identity);

        ItemToCompare itemWorld = transform.GetComponent<ItemToCompare>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    //public static ItemToCompare DropItem(Vector3 dropPosition, BrewItem item)
    //{
    //    Vector3 randomDir = UtilsClass.GetRandomDir();
    //    ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 8f, item);
    //    itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 40f, ForceMode2D.Impulse);
    //    return itemWorld;
    //}

    //spawn item to world 
    //ItemToCompare.SpawnItemWorld(new Vector3(), new ItemToCompare{itemType = ItemToCompare.name});


    private BrewItem item;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void SetItem(BrewItem item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

    }

    public BrewItem GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
