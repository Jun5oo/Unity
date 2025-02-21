using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableUnit : MonoBehaviour
{
    SpriteRenderer sprite; 

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.red; 
    }

    public void OnSelected()
    {
        sprite.color = Color.green; 
    }

    public void OnDeselected()
    {
        sprite.color = Color.red; 
    }
}
