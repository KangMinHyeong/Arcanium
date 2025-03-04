using UnityEngine;

public class RollingRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeedCoefficient = 5.0f;

    float rotationSpeed;

    void Update()
    {
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);


        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    


    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
}
