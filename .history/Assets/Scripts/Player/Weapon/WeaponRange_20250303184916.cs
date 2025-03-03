using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    public void SetRange(bool bRotate, float Range)
    {

    }

    public void SetRange_Circle(float Range)
    {
        transform.localScale = new Vector3(Range, Range, 1.0f);
    }

    public void SetRange_Box(float Range)
    {
        transform.localScale = new Vector3(Range, Range, 1.0f);
    }
}
