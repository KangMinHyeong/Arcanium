using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveUI : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        // if (EventSystem.current.IsPointerOverGameObject()) return;
        
        Debug.Log("OnDrag");
    }
}
