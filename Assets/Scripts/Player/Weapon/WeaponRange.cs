using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    public void SetRange(float Range)
    {
        transform.localScale = new Vector3(Range, Range, 1.0f);
    }
}
