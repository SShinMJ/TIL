using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// WayPoint�� ���ʹ̸� �̵�
public class EnemyMovement : MonoBehaviour
{
    Enemy enemy;

    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0, 5)]float speed = 2f;

    // OnEnable : setActive�� true ������ ������ ����ȴ�.
    void OnEnable()
    {
        //FollowPath();
        // "" ���� ���� �̸��� �Լ��� 1�� �ֱ�� �ݺ��ȴ�.
        //InvokeRepeating("FollowPath", 0, 1);
        // ������ ������� �ݺ����� �����Ƿ� �ڷ�ƾ�� ����Ѵ�.
        FindPath();
        StartCoroutine(FollowPath());
        ReturnToStart();
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FindPath()
    {
        // �� ���� �̵��ϰ� �ʱ�ȭ ���ش�.
        path.Clear();

        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in pathParent.transform)
        {
            path.Add(child.GetComponent<WayPoint>());
        }
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

        // ���� �ʰ� ���� �����ߴٸ�
        enemy.PanaltyMoney();
        gameObject.SetActive(false);
    }
}
