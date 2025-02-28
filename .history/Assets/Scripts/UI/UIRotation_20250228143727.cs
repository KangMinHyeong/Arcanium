using UnityEngine;

public class UIRotation : MonoBehaviour
{
    [SerializeField] float scaleFactor = 20.0f; // ✅ 크기 조정 비율

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        // float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        // transform.localScale = Vector3.one * distance * scaleFactor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);

        // ✅ UI 크기 고정 (카메라 거리와 상관없이)
        
    }
}
