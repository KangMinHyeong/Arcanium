using UnityEngine;

public class CameraMoveUI : MonoBehaviour
{
    PlayerController PC;

    void Start()
    {
        PC = FindFirstObjectByType<PlayerController>();    
    }

    public void CameraMove()
    {
        PC.CameraSticky = !PC.CameraSticky;
    }
}
