using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ItemData/OtherData")]
public class OtherData : ItemData
{
    public override Item CreateItem()
    {
        return new Other(this); 
    }
}
