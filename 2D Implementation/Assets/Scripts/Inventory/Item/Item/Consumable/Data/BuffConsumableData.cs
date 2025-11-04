using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/ItemData/ConsumableData/BuffConsumableData")]
public class BuffConsumableData : ConsumableData
{
    public string statType;
    public int buffValue;
    public float duration; 
}
