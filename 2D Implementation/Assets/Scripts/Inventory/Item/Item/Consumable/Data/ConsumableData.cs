public class ConsumableData : ItemData
{
    public override Item CreateItem()
    {
        return new Consumable(this); 
    }
}
