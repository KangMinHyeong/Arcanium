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

        if (EventSystem.current.IsPointerOverGameObject()) return;
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("현재 마우스 아래 3D 오브젝트: " + hit.collider.gameObject.name);
        }
        // Debug.Log(eventData.lastPress.name.ToString());
    }

    void CheckWayPoint(GameObject obj)
    {
        var wayPoint = obj.GetComponentInChildren<WayPoint>();
        if(!wayPoint || !wayPoint.IsPlacable)
        {
            // 붉은 표시
        }
        else
        {
            // 초록 표시
        }
    }
}
