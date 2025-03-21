using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] string Enemytag;
    
    List<GameObject> Enemies = new List<GameObject>();

    void Update()
    {
        if(Enemies.Count == 0) return;

        transform.LookAt(Enemies[0].transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;
        if(Enemies.Contains(other.gameObject)) return;

        Debug.Log("Add");
        Enemies.Add(other.gameObject);
    }

    void OriggerExit(Collider other)
    {
        if(other.tag != Enemytag) return;
        Debug.Log("Remove");
        Enemies.Remove(other.gameObject);
    }

}
