using UnityEngine.EventSystems;

public interface IDraggable: IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDragStart();
    public void OnDragEnd(); 
}
