using UnityEngine;

public class Slot
{
    int idx; 
    public int Index { get { return idx; } }

    Item item;
    public Item Item { get { return item; } }

    readonly public int maxAmount = 5; 
    public int amount; 

    public Slot(int idx)
    {
        this.idx = idx; 
    }

    public bool IsEmpty()
    {
        return Item == null; 
    }

    public void SetItem(Item item, int amount = 1)
    {
        this.item = item;
        this.amount = amount; 
    }

    public void Clear()
    {
        this.item = null;
        this.amount = 0; 
    }
}
