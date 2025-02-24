using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] string Enemytag;
    
    List<GameObject> Enemies = new List<GameObject>();

    void Update()
    {
        Debug.Log("Update");
        if(Enemies.Count == 0) return;

        transform.LookAt(Enemies[0].transform);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if(other.tag != Enemytag) return;
        if(Enemies.Contains(other.gameObject)) return;

        Debug.Log("Add");
        Enemies.Add(other.gameObject);
    }

    void OriggerExit(Collider other)
    {
        Debug.Log("OriggerExit");
        if(other.tag != Enemytag) return;
        Debug.Log("Remove");
        Enemies.Remove(other.gameObject);
    }

}
