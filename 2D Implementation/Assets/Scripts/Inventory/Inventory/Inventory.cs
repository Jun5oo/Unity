using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int INVENTORY_SIZE = 30;

    Slot[] slots;

    public Action<int> OnSlotChanged; 

    void Awake()
    {
        slots = new Slot[INVENTORY_SIZE];

        for(int i=0; i<INVENTORY_SIZE; i++)
        {
            slots[i] = new Slot(i); 
        }    
    }

    public void AddItem(ItemData data, int amount = 1)
    {
        Debug.Log(data.name);

        if (data.isStackable)
        {
            int slotIdx = FindStackableSlot(data); 
            
            if(slotIdx != -1)
            {
                slots[slotIdx].amount += amount;
                OnSlotChanged?.Invoke(slotIdx); 
                return; 
            }
        }

        int emptyIdx = FindEmptySlot(); 
       
        if(emptyIdx == -1)
        {
            Debug.Log("Inventory full");
            return; 
        }

        Item item = CreateItem(data); 
        slots[emptyIdx].SetItem(item, amount);
        OnSlotChanged?.Invoke(emptyIdx); 
    }

    public void RemoveItem(Slot slot)
    {

    }

    public int FindEmptySlot()
    {
        for(int i=0; i<INVENTORY_SIZE; i++)
        {
            if (slots[i].IsEmpty())
                return i; 
        }

        return -1; 
    }

    public int FindStackableSlot(ItemData itemData)
    {
        for(int i=0; i<INVENTORY_SIZE; i++)
        {
            if (!slots[i].IsEmpty() && slots[i].Item.ID == itemData.id && slots[i].maxAmount > slots[i].amount)
                return i; 
        }

        return -1; 
    }

    public Slot GetSlot(int idx)
    {
        if (idx >= INVENTORY_SIZE || idx < 0)
            return null; 

        return slots[idx]; 
    }

    public Item CreateItem(ItemData itemData)
    {
        Item item = itemData.CreateItem(); 
        return item; 
    }

   
}
