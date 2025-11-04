using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public static ItemTooltip instance;

    [SerializeField] GameObject panel;

    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject status; 

    public Action<Equipment> OnStatusUpdate; 

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        HideTooltip(); 
    }

    public void ShowTooltip(Item item)
    {
        if(item == null)
            return; 
        
        UpdateTooltip(item);
        panel.SetActive(true);
    }

    public void HideTooltip()
    {
        panel.SetActive(false);
    }

    public void UpdateTooltip(Item item)
    {
        itemImage.sprite = item.Icon;
        itemName.text = item.Name; 
        description.text = item.Description;

        if (item.Type != ItemType.Equipment)
            status.gameObject.SetActive(false); 
        
        else
        {
            OnStatusUpdate?.Invoke(item as Equipment);
            status.gameObject.SetActive(true);
        }
    }

}
