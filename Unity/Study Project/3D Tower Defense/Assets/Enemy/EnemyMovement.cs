using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// WayPoint로 에너미를 이동
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    void Start()
    {
        //FollowPath();
        // "" 내에 적힌 이름의 함수가 1초 주기로 반복된다.
        //InvokeRepeating("FollowPath", 0, 1);
        // 하지만 순서대로 반복되지 않으므로 코루틴을 사용한다.
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(var wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(1);
        }
    }
}
