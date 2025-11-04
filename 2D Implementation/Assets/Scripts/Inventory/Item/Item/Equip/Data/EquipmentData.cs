using System.Collections.Generic;
using UnityEngine;

public class EquipmentData : ItemData
{
    EquipmentType equipType; 

    public int attack;
    public int defense;
    public int hp;
    public int mp;
    public int speed;

    // List<ItemEffect> 
    public StatusRange statusRange;

    public override Item CreateItem()
    {
        Equipment equip = new Equipment(this); 

        int atk = Random.Range(statusRange.attackRange.x, statusRange.attackRange.y + 1);
        int def = Random.Range(statusRange.defenseRange.x, statusRange.defenseRange.y + 1); 
        int hp = Random.Range(statusRange.hpRange.x, statusRange.hpRange.y + 1);
        int mp = Random.Range(statusRange.mpRange.x, statusRange.mpRange.y + 1);
        int speed = Random.Range(statusRange.speedRange.x, statusRange.speedRange.y + 1);

        equip.ApplyAttack(atk); 
        equip.ApplyDefense(def);
        equip.ApplyHP(hp);
        equip.ApplyMP(mp);
        equip.ApplySpeed(speed);

        return equip; 
    }
}
