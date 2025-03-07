using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 1.0f;
    [SerializeField] float MoveSpeed = 1.0f;
    

    List<WayPoint> paths = new List<WayPoint>();

    Enemy enemy;
    Coroutine MoveCoroutine;
    Vector3 direction;
    float RotationSpeed = 11.5f;

    bool bRotate = false;

    void OnEnable() 
    {
        bRotate = true;
        FindPath();
        MoveCoroutine = StartCoroutine(Move());
    }

    void OnDisable()
    {
        bRotate = false;
    }

    void Update()
    {
        if(!bRotate) return;
        var Dir = (direction - transform.position).normalized;

        if (Dir.sqrMagnitude > 0.001f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(Dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
    }

    public void Init(Enemy enemy, EnemyData EnemyInfo)
    {
        this.enemy = enemy;

        TargetMoveTime = EnemyInfo.EnemyMoveTime;
        MoveSpeed = EnemyInfo.EnemyMoveSpeed;
    }

    void FindPath()
    {
        paths.Clear();

        var waypoints = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform waypoint in waypoints.transform) 
        {
            paths.Add(waypoint.GetComponent<WayPoint>());
        }

        transform.position = paths[0].transform.position;
    }

    IEnumerator Move()
    {
        for(int i = 1; i<paths.Count; i++)
        {   
            var currentpos = transform.position;
            direction = paths[i].transform.position;

            // transform.LookAt(paths[i].transform);

            float CurrentMoveTime = 0.0f;
            while(enabled && CurrentMoveTime < TargetMoveTime)
            {
                CurrentMoveTime += Time.deltaTime * MoveSpeed;
                transform.position = Vector3.Lerp(currentpos, direction, CurrentMoveTime);
                yield return new WaitForEndOfFrame();
            }
        }

        enemy.ApplyDamage();
    }

    public void Stop()
    {
        enabled = false;
        
        if(MoveCoroutine == null) return;
        StopCoroutine(MoveCoroutine);
        MoveCoroutine = null;
    }
}
