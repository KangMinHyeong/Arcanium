using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] GameObject RotateMesh;
    [SerializeField] string Enemytag;

    List<Transform> Enemies = new List<Transform>();

    Transform Target;
    bool bEnemyTrigger = false;
    public bool IsEnemyTrigger { get {return bEnemyTrigger;}}


    void Update()
    {
        Enemies.RemoveAll(enemy => !enemy.gameObject.activeInHierarchy); 
        if (Enemies.Count == 0) { bEnemyTrigger = false; return; }

        Target = Enemies[0];
        RotateMesh.transform.LookAt(Target);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;
        if(Enemies.Contains(other.gameObject.transform)) return;

        bEnemyTrigger = true;

        Enemies.Add(other.gameObject.transform);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != Enemytag) return;

        Enemies.Remove(other.gameObject.transform);
    }
}
