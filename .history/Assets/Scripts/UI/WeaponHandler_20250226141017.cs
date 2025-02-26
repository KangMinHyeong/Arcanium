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

        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            Debug.Log("UI 클릭");
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("현재 마우스 아래 3D 오브젝트: " + hit.collider.gameObject.name);
        }
        // Debug.Log(eventData.lastPress.name.ToString());
        
    }
}
