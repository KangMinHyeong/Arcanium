using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 1.0f;
    [SerializeField] float MoveSpeed = 1.0f;

    List<WayPoint> paths = new List<WayPoint>();

    Enemy enemy;

    void OnEnable() 
    {
        bMove = true;

        FindPath();
        StartCoroutine(Move());
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
            if(!bMove) yield return null;

            var currentpos = transform.position;
            var targetpos = paths[i].transform.position;

            transform.LookAt(paths[i].transform);

            float CurrentMoveTime = 0.0f;
            while(CurrentMoveTime < TargetMoveTime)
            {
                if(!bMove) yield return null;

                CurrentMoveTime += Time.deltaTime * MoveSpeed;
                transform.position = Vector3.Lerp(currentpos, targetpos, CurrentMoveTime);
                yield return new WaitForEndOfFrame();
            }
        }

        enemy.ApplyDamage();
    }
}
