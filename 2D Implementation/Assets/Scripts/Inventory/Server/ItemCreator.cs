using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] Inventory inventory; 

    [SerializeField] List<ItemData> items = new List<ItemData>();

    public void CreateRandomItem()
    {
        int randomIdx = Random.Range(0, items.Count);
        inventory.AddItem(items[randomIdx]); 
    }
}
