using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] string Enemytag;
    

    List<GameObject> Enemies = List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;


    }
}
