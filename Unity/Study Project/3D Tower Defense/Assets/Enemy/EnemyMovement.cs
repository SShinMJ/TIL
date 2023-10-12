using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// WayPoint�� ���ʹ̸� �̵�
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    void Start()
    {
        //FollowPath();
        // "" ���� ���� �̸��� �Լ��� 1�� �ֱ�� �ݺ��ȴ�.
        //InvokeRepeating("FollowPath", 0, 1);
        // ������ ������� �ݺ����� �����Ƿ� �ڷ�ƾ�� ����Ѵ�.
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
