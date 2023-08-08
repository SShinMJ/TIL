using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 총알이 위로(앞으로) 날아가게 한다.
// 필요 : 총알의 방향, 속도.

// 목표 : 총알이 적과 충돌하면, 총알과 적이 삭제된다.
public class PlayerBullet : MonoBehaviour
{
    // 속도
    public float speed = 5.0f;
    // 방향
    public Vector3 dir = Vector3.up;

    void Update()
    {
        // 총알이 위로(앞으로) 날아간다.
        transform.position += dir * speed * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision others)
    //{
    //    if (others.gameObject.tag == "Enemy")
    //    {
    //        Destroy(others.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}