using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// WayPoint�� ���ʹ̸� �̵�
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0, 5)]float speed = 2f;

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
            // �����̵��ϴ� �� ó�� �̵����� �ʰ�,
            //transform.position = wayPoint.transform.position;
            // �ε巴�� ���� ĭ���� �Ѿ�� �Ѵ�.
            Vector3 startPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            float travelPercent = 0f;

            // ������ �ϴ� ��ġ�� �ٶ󺻴� == �����̴� �������� ȸ���Ѵ�.
            transform.LookAt(wayPoint.transform);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                // Lerp : ��������. �� �� ������ �Ÿ��� travelPercent%��ŭ�� ���� ��ȯ.
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); ;
                
                // �� �������� ������ ������
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
