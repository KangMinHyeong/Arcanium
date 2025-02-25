using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    FocusTarget FT;

    void Awake() 
    {
        FT = GetComponent<FocusTarget>();
    }

    
}
