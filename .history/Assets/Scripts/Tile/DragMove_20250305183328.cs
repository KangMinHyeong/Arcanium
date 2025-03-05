using UnityEngine;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour
{
    public void SetActive(bool value)
    {

    }

    void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Debug.Log("OnMouseDrag");
    }
}
