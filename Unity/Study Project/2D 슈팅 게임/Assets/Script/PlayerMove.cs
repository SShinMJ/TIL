using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 플레이어를 사용자 입력에 따라 움직인다.

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 playerPos = new Vector3 (0, 0, 0);
    Vector3 enemyPos = new Vector3(5, 5, 0);

    void Start()
    {
        // 벡터 점과 점의 길이(삼각형의 변구하기와 같다)
        Vector3 direction = enemyPos - playerPos;
        // magnitude : 벡터의 길이 출력
        float distance = direction.magnitude;
    }

    // p = vt
    // vt = v0 + at

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        transform.Translate(dir * speed * Time.deltaTime);
        // == transform.position = transform.position + dir * speed * Time.deltaTime;
        //                         현재위치 + 방향 * 속도 * 프레임 속도 맞추기(다음 프레임이 갱실될 때까지 속도)
    }
}
