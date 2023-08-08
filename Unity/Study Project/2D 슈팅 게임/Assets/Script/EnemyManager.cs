using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 적을 일정 시간마다 생성.
// 필요 : 현재 시간, 일정 시간, 적 오브젝트
// 순서1. 현재 시간부터 일정 시간이 흐르면,
// 순서2. 적을 EnemyManager 위치에 생성한다.

// 추가 : 적 생성 주기(일정 시간)을 랜덤 시간으로 설정한다.
public class EnemyManager : MonoBehaviour
{
    // 특정 시간(default : 2초)
    float creatTime;
    // 적 생성 시간 최소/최대
    public int creatMinTime = 2;
    public int creatMaxTime = 5;
    // 현재 시간
    float currentTime = 0;
    // 적 오브젝트
    public GameObject Enemy;

    private void Start()
    {
        // 적 생성 주기(일정 시간)을 랜덤 시간으로 설정
        creatTime = Random.Range(creatMinTime, creatMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐른다.
        currentTime += Time.deltaTime;
        // 1. 일정 시간 이상 지날 때 마다
        if (currentTime >= creatTime)
        {
            // 2. 적을 EnemyManager 위치에 생성한다.
            GameObject EnemyObj = Instantiate(Enemy);
            EnemyObj.transform.position = transform.position;

            // 카운트 시간 초기화
            currentTime = 0;
        }
    }
}