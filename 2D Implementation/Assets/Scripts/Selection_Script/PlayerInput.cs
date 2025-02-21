using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    public Camera camera;
    // public LayerMask unitLayer; 
    [SerializeField]
    private RectTransform selectionBox;

    private Vector2 startMousePosition;

    [SerializeField]
    private float dragDelay = 0.1f;
    private float mouseDownTime;

    private void Update()
    {
        HandleSelectionBox();
    }

    private void HandleSelectionBox()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // sizeDelta = Vector2 of width and height
            selectionBox.sizeDelta = Vector2.zero;
            selectionBox.gameObject.SetActive(true);
            startMousePosition = Input.mousePosition;
            mouseDownTime = Time.time;
        }

        else if (Input.GetKey(KeyCode.Mouse0) && mouseDownTime + dragDelay < Time.time)
        {
            ResizeSelectionBox();
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            selectionBox.sizeDelta = Vector2.zero;
            selectionBox.gameObject.SetActive(false);

            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
            
            if (hit && hit.collider.TryGetComponent<SelectableUnit>(out SelectableUnit unit))
            {
                SelectionManager.Instance.DeselectAll();
                SelectionManager.Instance.Select(unit); 
            }

            else if (mouseDownTime + dragDelay > Time.time)
            {
                SelectionManager.Instance.DeselectAll(); 
            }

            mouseDownTime = 0;
        }
    }

    private void ResizeSelectionBox()
    {
        // Input.mousePosition = the current mouse position in pixel coordinates 
        // startMousePosition = mouse position that is firstly clicked
        float width = Input.mousePosition.x - startMousePosition.x;
        float height = Input.mousePosition.y - startMousePosition.y;

        // Input.mousePosition (The bottom-left of the screen or window is at (0,0))
        // In the Editor, you should set your selectionBox's anchor as bottom left, which is same as Input.mouse 
        selectionBox.anchoredPosition = startMousePosition + new Vector2(width/2, height/2);
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        // Create a bounds that set selectionBox.achoredPosition as center, and size as sizeDelta 
        Bounds bounds = new Bounds(selectionBox.anchoredPosition, selectionBox.sizeDelta); 

        for(int i=0; i<SelectionManager.Instance.AvailableUnits.Count; i++)
        {
            // Check selectable object is in bounds 
            if (UnitIsInSelectionBox(camera.WorldToScreenPoint(SelectionManager.Instance.AvailableUnits[i].transform.position), bounds))
                SelectionManager.Instance.Select(SelectionManager.Instance.AvailableUnits[i]);
            else
                SelectionManager.Instance.Deselect(SelectionManager.Instance.AvailableUnits[i]); 
        }
    }

    private bool UnitIsInSelectionBox(Vector3 position, Bounds bounds)
    {
        return position.x > bounds.min.x && position.x < bounds.max.x && position.y > bounds.min.y && position.y < bounds.max.y; 
    }
}
