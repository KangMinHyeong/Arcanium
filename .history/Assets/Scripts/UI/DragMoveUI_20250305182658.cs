using UnityEngine;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour
{
    void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Debug.Log("");
    }
}
