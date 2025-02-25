using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> paths = new List<WayPoint>();
    [SerializeField] float TargetMoveTime = 1.0f;
    [SerializeField] float MoveSpeed = 1.0f;

    void OnEnable() 
    {
        Debug.Log("OnEnable");
        transform.position = paths[0].transform.position;
        StartCoroutine(Move());
    }


    IEnumerator Move()
    {
        foreach(var path in paths)
        {   
            var currentpos = transform.position;
            var targetpos = path.transform.position;

            transform.LookAt(path.transform);

            float CurrentMoveTime = 0.0f;
            while(CurrentMoveTime < TargetMoveTime)
            {
                CurrentMoveTime += Time.deltaTime * MoveSpeed;
                transform.position = Vector3.Lerp(currentpos, targetpos, CurrentMoveTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
