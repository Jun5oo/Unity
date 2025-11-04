using UnityEngine;

[System.Serializable]
public struct StatusRange
{
    // 장비에 붙을 수 있는 랜덤 수치 
    public Vector2Int attackRange;
    public Vector2Int defenseRange;
    public Vector2Int hpRange;
    public Vector2Int mpRange;
    public Vector2Int speedRange; 
}
