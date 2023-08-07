using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 사용자 입력(Space)을 받아 총알을 생성한다.
public class PlayerShot : MonoBehaviour
{
    public GameObject Bullet;

    void Update()
    {
        // 'Space' 입력을 받는다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 총알을 생성 (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // 총알을 플레이어 위치로 설정
            bulletObject.transform.position = transform.position;
        }
    }
}
