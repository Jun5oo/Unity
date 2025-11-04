using System.Collections.Generic;
using UnityEngine; 

public class Equipment : Item
{
    public int attack, bonusAttack;
    public int defense, bonusDefense;
    public int hp, bonusHp;
    public int mp, bonusMp;
    public int speed, bonusSpeed; 

    public Equipment(EquipmentData data) : base(data)
    {
        this.attack = data.attack; 
        this.defense = data.defense;
        this.hp = data.hp;
        this.mp = data.mp;
        this.speed = data.speed;

        bonusAttack = 0; 
        bonusDefense = 0;
        bonusHp = 0;
        bonusMp = 0; 
        bonusSpeed = 0;
    }

    public bool CanEquip()
    {
        return true; 
    }

    public void Equip()
    {
        Debug.Log($"{Name}이 장착되었습니다."); 
    }

    public void ApplyStatus(Dictionary<string, int> additionalStatus)
    {
        if(additionalStatus.TryGetValue("Attack", out var attack))
            bonusAttack = attack;
        if (additionalStatus.TryGetValue("Defense", out var defense))
            bonusDefense = defense;
        if (additionalStatus.TryGetValue("HP", out var hp))
            bonusHp = hp; 
        if(additionalStatus.TryGetValue("MP", out var mp))
            bonusMp = mp;
        if(additionalStatus.TryGetValue("Speed", out var speed))
            bonusSpeed = speed;
    }

    public void ApplyAttack(int bonus)
    {
        bonusAttack = bonus; 
    }

    public void ApplyDefense(int bonus)
    {
        bonusDefense = bonus; 
    }

    public void ApplyHP(int bonus)
    {
        bonusHp = bonus; 
    }

    public void ApplyMP(int bonus)
    {
        bonusMp = bonus; 
    }

    public void ApplySpeed(int bonus)
    {
        bonusSpeed = bonus; 
    }
}
