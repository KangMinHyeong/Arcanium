using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("sdf");
    }
}
