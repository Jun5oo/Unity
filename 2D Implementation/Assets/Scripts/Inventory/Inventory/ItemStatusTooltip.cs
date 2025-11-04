using TMPro;
using UnityEngine;

public class ItemStatusTooltip : MonoBehaviour
{
    [SerializeField] ItemTooltip tooltip; 

    [SerializeField] TextMeshProUGUI atkText; 
    [SerializeField] TextMeshProUGUI defText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI mpTExt;
    [SerializeField] TextMeshProUGUI speedText; 

    void Start()
    {
        tooltip.OnStatusUpdate -= UpdateStatus;
        tooltip.OnStatusUpdate += UpdateStatus;
    }

    void UpdateStatus(Equipment item)
    {
        Debug.Log("StatusTooltip Update!"); 
        atkText.text = $"ATK: {item.attack} + <color=green>{item.bonusAttack}</color>";
        defText.text = $"DEF: {item.defense} + <color=green>{item.bonusDefense}</color>";
        hpText.text = $"HP: {item.hp} + <color=green>{item.bonusHp}</color>";
        mpTExt.text = $"MP: {item.mp} + <color=green>{item.bonusMp}</color>";
        speedText.text = $"SPEED: {item.speed} + <color=green>{item.bonusSpeed}</color>";
;    }
}
