using UnityEngine;

public class UIRotation : MonoBehaviour
{
    float fixedSize = 1.0f; // ✅ 일정한 크기 유지
    [SerializeField] float scaleFactor = 20.0f; // ✅ 크기 조정 비율

    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward);

        // ✅ UI 크기 고정 (카메라 거리와 상관없이)
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        transform.localScale = Vector3.one * (fixedSize / distance) * scaleFactor;
    }
}
