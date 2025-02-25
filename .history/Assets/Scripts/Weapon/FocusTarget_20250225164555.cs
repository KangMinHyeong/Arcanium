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
        Enemies.RemoveAll(enemy => !enemy.gameObject.activeInHierarchy); // ✅ 비활성화된 적 모두 제거
        if (Enemies.Count == 0) { bEnemyTrigger = false; return; }

        RotateMesh.transform.LookAt(Enemies[0]); // ✅ 첫 번째 활성화된 적을 바라
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
