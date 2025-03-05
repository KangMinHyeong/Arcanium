using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveUI : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }
}
