using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager instance;  
    public static SelectionManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<SelectionManager>();

            return instance; 
        }
        set
        {
            instance = value; 
        }
    }

    [SerializeField]
    public HashSet<SelectableUnit> selectedUnits = new HashSet<SelectableUnit>();
    public List<SelectableUnit> AvailableUnits = new List<SelectableUnit>();

    public void Select(SelectableUnit unit)
    {
        selectedUnits.Add(unit);
        unit.OnSelected(); 
    }

    public void Deselect(SelectableUnit unit)
    {
        selectedUnits.Remove(unit);
        unit.OnDeselected();
    }

    public void DeselectAll()
    {
        foreach (SelectableUnit unit in selectedUnits)
            unit.OnDeselected();

        selectedUnits.Clear(); 
    }   

    public bool IsSelected(SelectableUnit unit)
    {
        return selectedUnits.Contains(unit);
    }
}
