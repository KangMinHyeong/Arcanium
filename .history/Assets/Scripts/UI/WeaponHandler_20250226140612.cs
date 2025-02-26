using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IPointerClickHandler, IDragHandler
{


    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("sdf");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // WayPoint wayPoint = 

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log("현재 마우스 아래 UI: " + eventData.pointerCurrentRaycast.gameObject.name);
        }
        // Debug.Log(eventData.lastPress.name.ToString());
        
    }
}
