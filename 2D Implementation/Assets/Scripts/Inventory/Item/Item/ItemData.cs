using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public string description;
    public Sprite icon;

    public ItemType itemType;
    public bool isStackable;

    public abstract Item CreateItem();
}
