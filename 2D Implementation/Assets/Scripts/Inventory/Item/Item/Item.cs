using UnityEngine;

public abstract class Item
{
    public ItemData itemData;

    public Item(ItemData data)
    {
        this.itemData = data;
    }

    public string ID => itemData.id;
    public string Name => itemData.itemName;
    public string Description => itemData.description;
    public Sprite Icon => itemData.icon;
    public ItemType Type => itemData.itemType;
    public bool Stackable => itemData.isStackable;
}
