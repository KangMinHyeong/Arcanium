using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> paths = new List<WayPoint>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Move()
    {
        foreach(var path in paths)
        {   
            transform.position = path.transform.position;

            yield return new WaitForSeconds(1.0f);
        }
    }
}
