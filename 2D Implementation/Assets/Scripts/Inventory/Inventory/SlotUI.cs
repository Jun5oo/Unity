using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI amount;

    int slotIndex;

    public Action<int> OnSlotHoverEnter; 
    public Action OnSlotHoverExit; 

    public void Setup(int index)
    {
        slotIndex = index; 
    }
    public void SetIcon(Sprite sprite)
    {
        if(sprite != null)
        {
            this.itemIcon.sprite = sprite;
            itemIcon.gameObject.SetActive(true); 
        }
    }
    public void SetAmount(int amount)
    {
        if (amount > 1)
        {
            this.amount.text = amount.ToString();
            this.amount.gameObject.SetActive(true);
        }

        else
            this.amount.gameObject.SetActive(false); 
    }
    public void Clear()
    {
        this.itemIcon.sprite = null;
        this.amount.text = 0.ToString(); 

        this.itemIcon.gameObject.SetActive(false);
        this.amount.gameObject.SetActive(false); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnSlotHoverExit?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSlotHoverEnter?.Invoke(slotIndex);
    }
}
