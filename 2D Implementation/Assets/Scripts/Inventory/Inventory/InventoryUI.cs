using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject slotPrefab;
    [SerializeField] RectTransform content;

    Inventory inventory; 
    List<SlotUI> slots = new List<SlotUI>();

    void Start()
    {
        Init(); 
    }
    public void Init()
    {
        CreateSlot();

        this.inventory = this.GetComponent<Inventory>();
        
        this.inventory.OnSlotChanged -= UpdateSlot; 
        this.inventory.OnSlotChanged += UpdateSlot;
    }
    void CreateSlot()
    {
        for(int i=0; i<30; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, content.transform);
            SlotUI slotUI = slotObj.GetComponent<SlotUI>();
            if(slotUI == null)
            {
                Debug.LogError("Cannot found SlotUI component from SlotPrefab");
                return; 
            }

            slotUI.Setup(i);
            
            slotUI.OnSlotHoverEnter -= HandleSlotEnterHover;
            slotUI.OnSlotHoverEnter += HandleSlotEnterHover;
            slotUI.OnSlotHoverExit -= HandleSlotExitHover;
            slotUI.OnSlotHoverExit += HandleSlotExitHover; 
            
            slots.Add(slotUI); 
        }
    }
    void HandleSlotEnterHover(int slotIndex)
    {
        Slot slot = inventory.GetSlot(slotIndex); 
        
        if(slot == null)
        {
            Debug.Log("Slot not found");
            return; 
        }

        if(slot.Item == null)
        {
            Debug.Log("No item on this slot");
            return; 
        }

        ItemTooltip.instance.ShowTooltip(slot.Item); 
    }
    void HandleSlotExitHover()
    {
        ItemTooltip.instance.HideTooltip(); 
    }
    public void UpdateSlot(int idx)
    {
        if (idx >= slots.Count || idx < 0) 
            return;

        Slot slot = inventory.GetSlot(idx);
        
        if (slot == null) 
            return;

        SlotUI slotUI = slots[idx];

        if (!slot.IsEmpty())
        {
            slotUI.SetIcon(slot.Item.Icon);
            slotUI.SetAmount(slot.amount); 
        }
        else
            slotUI.Clear(); 
    }
}
