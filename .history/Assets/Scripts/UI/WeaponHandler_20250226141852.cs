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
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            CheckWayPoint(hit.collider.gameObject);
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
