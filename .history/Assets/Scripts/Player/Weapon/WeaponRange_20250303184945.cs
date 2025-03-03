using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    public void SetRange(bool bRotate, float Range)
    {
        if(bRotate)
        {
            SetRange_Circle(Range);
        }
        else
        {
            SetRange_Box(Range);
        }
    }

    void SetRange_Circle(float Range)
    {
        transform.localScale = new Vector3(Range, Range, 1.0f);
    }

    void SetRange_Box(float Range)
    {
        transform.localScale = new Vector3(Range, Range, 1.0f);
    }
}
