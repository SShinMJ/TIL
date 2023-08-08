using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // 특정 시간(default : 2초)
    float creatTime;
    // 적 총알 생성 시간 최소/최대
    public int creatMinTime = 2;
    public int creatMaxTime = 10;
    // 현재 시간
    float currentTime = 0;
    // 적 오브젝트
    public GameObject Bullet;
    private void Start()
    {
        // 적의 총알 생성 주기(일정 시간)을 랜덤 시간으로 설정
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
            // 총알을 생성 (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // 총알을 적의 위치로 설정
            bulletObject.transform.position = transform.position;

            // 카운트 시간 초기화
            currentTime = 0;
        }
    }
}