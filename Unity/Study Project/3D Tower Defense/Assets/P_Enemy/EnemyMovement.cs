using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// WayPoint로 에너미를 이동
public class EnemyMovement : MonoBehaviour
{
    Enemy enemy;

    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0, 5)]float speed = 2f;

    // OnEnable : setActive가 true 상태일 때마다 실행된다.
    void OnEnable()
    {
        //FollowPath();
        // "" 내에 적힌 이름의 함수가 1초 주기로 반복된다.
        //InvokeRepeating("FollowPath", 0, 1);
        // 하지만 순서대로 반복되지 않으므로 코루틴을 사용한다.
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
        // 한 번만 이동하게 초기화 해준다.
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
            // 순간이동하는 것 처럼 이동하지 않고,
            //transform.position = wayPoint.transform.position;
            // 부드럽게 다음 칸으로 넘어가게 한다.
            Vector3 startPos = transform.position;
            Vector3 endPos = wayPoint.transform.position;
            float travelPercent = 0f;

            // 가고자 하는 위치를 바라본다 == 움직이는 방향으로 회전한다.
            transform.LookAt(wayPoint.transform);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                // Lerp : 선형보간. 두 점 사이의 거리의 travelPercent%만큼의 값을 반환.
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); ;
                
                // 한 프레임이 지나갈 때마다
                yield return new WaitForEndOfFrame();
            }
        }

        // 죽지 않고 끝에 도달했다면
        enemy.PanaltyMoney();
        gameObject.SetActive(false);
    }
}
