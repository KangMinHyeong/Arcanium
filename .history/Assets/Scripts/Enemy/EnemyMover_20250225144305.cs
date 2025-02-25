using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float TargetMoveTime = 1.0f;
    [SerializeField] float MoveSpeed = 1.0f;

    List<WayPoint> paths = new List<WayPoint>();

    void OnEnable() 
    {
        FindPath();
        
        StartCoroutine(Move());
    }

    void FindPath()
    {

        transform.position = paths[0].transform.position;
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

        gameObject.SetActive(false);
    }
}
