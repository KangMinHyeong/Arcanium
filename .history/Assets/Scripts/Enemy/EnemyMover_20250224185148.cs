using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> paths = new List<WayPoint>();
    [SerializeField] float TargetMoveTime = 1.0f;

    void Start()
    {
        StartCoroutine(Move());
    }


    IEnumerator Move()
    {
        foreach(var path in paths)
        {   
            var currentpos = transform.position;
            var targetpos = path.transform.position;

            float CurrentMoveTime = 0.0f;
            while(CurrentMoveTime < TargetMoveTime)
            {
                CurrentMoveTime += Time.deltaTime;

                Mathf.Lerp()
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
