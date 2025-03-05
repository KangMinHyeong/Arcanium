using UnityEngine;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour
{
    public void SetActive(bool value)
    {
        transform.root.gameObject.SetActive(value);
    }

    // void OnMouseDrag()
    // {
    //     if (EventSystem.current.IsPointerOverGameObject()) return;

    //     Debug.Log("OnMouseDrag");
    // }
}
