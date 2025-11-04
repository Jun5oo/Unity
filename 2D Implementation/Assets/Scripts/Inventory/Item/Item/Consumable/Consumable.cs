using UnityEngine; 

public class Consumable : Item
{
    public Consumable(ItemData data) : base(data)
    {

    }

    public virtual void Use()
    {
        Debug.Log($"{Name}이 사용했습니다."); 
    }
}
