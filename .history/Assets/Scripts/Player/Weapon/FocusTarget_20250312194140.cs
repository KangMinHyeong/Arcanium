using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : MonoBehaviour
{
    [SerializeField] GameObject RotateMesh;
    [SerializeField] string Enemytag;
    [SerializeField] float rotationSpeed = 3.0f;

    List<EnemyMover> Enemies = new List<EnemyMover>();

    Transform Target; 
    bool bRotate = false;
    bool bEnemyTrigger = false;

    public Transform GetTarget { get {return Target;}}
    public bool IsEnemyTrigger { get {return bEnemyTrigger;}}
    public bool IsRotate { get {return bRotate;} set {bRotate = value;}}
    public List<EnemyMover> GetEnemies { get {return Enemies;}}

    void Update()
    {
        Enemies.RemoveAll(enemy => !enemy.enabled); 
        if (Enemies.Count == 0) { bEnemyTrigger = false; return; }
        
        if(!bRotate) return;
        Target = Enemies[0].transform;
        Vector3 direction = (Target.position - RotateMesh.transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        RotateMesh.transform.rotation = Quaternion.Lerp(RotateMesh.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != Enemytag) return;

        var EnemyMover = other.GetComponentInParent<EnemyMover>();
        if(!EnemyMover || Enemies.Contains(EnemyMover)) return;

        bEnemyTrigger = true;
        Enemies.Add(EnemyMover);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != Enemytag) return;

        var EnemyMover = other.GetComponentInParent<EnemyMover>();
        if(EnemyMover) Enemies.Remove(EnemyMover);
    }
}
