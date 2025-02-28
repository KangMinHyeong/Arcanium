using UnityEngine;

public class UIRotation : MonoBehaviour
{
    [SerializeField] float scaleFactor = 0.05f; // 크기 조정 비율

    Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward);

        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        transform.localScale = Vector3.one * distance * scaleFactor;
    }
}
