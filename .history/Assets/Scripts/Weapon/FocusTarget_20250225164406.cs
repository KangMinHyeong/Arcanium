using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] GameObject RotateMesh;
    [SerializeField] string Enemytag;
    
    List<Transform> Enemies = new List<Transform>();
    bool bEnemyTrigger = false;
    public bool IsEnemyTrigger { get {return bEnemyTrigger;}}


    void Update()
    {
        if (Enemies.Count == 0) { bEnemyTrigger = false; return; }

        for (int i = Enemies.Count - 1; i >= 0; i--) 
        {
            if (Enemies[i].gameObject.activeInHierarchy)
            {
                RotateMesh.transform.LookAt(Enemies[i]); // 첫 번째 활성화된 적을 바라봄
                break;
            }
            else
            {
                Enemies.RemoveAt(i); 
            }
        }
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
