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

    float CurrentMoveSpeed;
    float RotationSpeed = 11.5f;

    bool bRotate = false;

    // Debuff 관련 변수
    bool bSlow = false;
    float SlowCoeffecient;
    float SlowTime;
    Coroutine SlowCoroutine;

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
        if (bRotate) RotateEnemy();
        
    }

    private void RotateEnemy()
    {
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

        CurrentMoveSpeed = MoveSpeed;
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
                CurrentMoveTime += Time.deltaTime * CurrentMoveSpeed;
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

    public void SlowMoveSpeed(float Coefficient, float Time)
    {
        if(bSlow) // Slow 상태이면 시간 갱신 및 Coefficient 비교
        {
            if(SlowCoeffecient < Coefficient) return;
            if(SlowTime > Time) return;
        }
        
        if(MoveCoroutine != null)
        {
            StopCoroutine(MoveCoroutine);
            CurrentMoveSpeed = MoveSpeed;
        }
        
        MoveCoroutine = StartCoroutine(Slow(Coefficient, Time));
    }

    IEnumerator Slow(float Coefficient, float Time)
    {
        SlowCoeffecient = Coefficient;
        bSlow = true;

        CurrentMoveSpeed = MoveSpeed * SlowCoeffecient;
        
        yield return new WaitForSeconds(Time);

        SlowCoeffecient = 1.0f;
        bSlow = false;
        
        CurrentMoveSpeed = MoveSpeed;
    }
}
