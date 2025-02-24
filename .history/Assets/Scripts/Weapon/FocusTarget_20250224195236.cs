using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] GameObject RotateMesh;
    [SerializeField] string Enemytag;
    
    List<GameObject> Enemies = new List<GameObject>();

    void Update()
    {
        if(Enemies.Count == 0) return;

        RotateMesh.transform.LookAt(Enemies[0].transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;
        if(Enemies.Contains(other.gameObject)) return;

        Enemies.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != Enemytag) return;

        Enemies.Remove(other.gameObject);
    }

}
