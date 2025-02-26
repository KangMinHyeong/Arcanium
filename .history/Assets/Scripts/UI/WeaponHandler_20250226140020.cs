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

        Debug.Log(eventData.lastPress.name.ToString());
        
    }
}
