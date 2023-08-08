using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 사용자 입력(Space)을 받아 총알을 생성한다.

// 목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
// 속성: 스킬레벨
// 단계1. 아이템을 먹었다면
// 단계2. 스킬레벨이 1 올라간다.
// 단계3. 아이템을 파괴한다.
// 단계4. 아이템 이펙트를 생성한다.
public class PlayerShot : MonoBehaviour
{
    public GameObject Bullet;

    public int skillLevel = 0;
    public int degree = 15;


    void Update()
    {
        // 'Space' 입력을 받는다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 스킬 레밸에 따라 발사될 총알의 갯수와 방향이 정해진다.
            ExcuteSkill(skillLevel);
        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill0();
                break;
            case 1:
                ExcuteSkill1();
                break;
            case 2:
                ExcuteSkill2();
                break;
            case 3:
                ExcuteSkill3(degree);
                break;
        }

        // 한개의 총알이 발사된다.
        void ExcuteSkill0()
        {
            // 총알을 생성 (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // 총알을 플레이어 위치로 설정
            bulletObject.transform.position = transform.position;
        }

        // 두개의 총알이 발사된다.
        void ExcuteSkill1()
        {
            // 총알을 생성 (Instantiate)
            GameObject bulletGO = Instantiate(Bullet);
            GameObject bulletGO1 = Instantiate(Bullet);

            // 총알을 플레이어 위치로 설정, 양 날개에서 발사되도록 위치 조정.
            bulletGO.transform.position = transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO1.transform.position = transform.position + new Vector3(0.3f, 0, 0);
        }

        // 세개의 총알이 발사된다.
        // 1, 2, 3 총알 중 1, 3 총알이 각각 Z축으로 -30도, 30도 회전 후 발사된다.
        void ExcuteSkill2()
        {
            // 총알을 생성 (Instantiate)
            GameObject bulletGO = Instantiate(Bullet);

            // 총알을 플레이어 위치로 설정.
            bulletGO.transform.position = transform.position;

            // 나머지 총알을 생성 (Instantiate)
            GameObject bulletGO2 = Instantiate(Bullet);
            GameObject bulletGO3 = Instantiate(Bullet);

            // 총알을 플레이어 위치에서 왼 날개쪽으로 설정, 왼쪽대각선(-30도)로 방향을 기운다.
            bulletGO2.transform.position = transform.position + new Vector3(-0.3f, 0, 0);
            bulletGO2.transform.rotation = Quaternion.Euler(0, 0, 30);
            bulletGO2.GetComponent<PlayerBullet>().dir = bulletGO2.transform.up;

            // 총알을 플레이어 위치에서 오른 날개쪽으로 설정, 오른쪽대각선(30도)로 방향을 기운다.
            bulletGO3.transform.position = transform.position + new Vector3(0.3f, 0, 0);
            bulletGO3.transform.rotation = Quaternion.Euler(0, 0, -30);
            bulletGO3.GetComponent<PlayerBullet>().dir = bulletGO3.transform.up;
        }


        // _degree가 15이므로 총 24개의 총알을 360도로 발사한다.
        void ExcuteSkill3(int _degree)
        {
            int numOfBullet = 360 / degree;

            // 24개의 총알이 15도씩 방향이 회전하여 생성된다.
            for (int i = 0; i < numOfBullet; i++)
            {
                // 총알을 생성 (Instantiate)
                GameObject bulletGO = Instantiate(Bullet);

                // 순서3: 총알의 위치를 플레이어의 위치로 정해주고 싶다.
                bulletGO.transform.position = transform.position;
                bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
                bulletGO.GetComponent<PlayerBullet>().dir = bulletGO.transform.up;
            }
        }
    }

    // 목표2: 아이템을 먹었다면, 스킬 레벨이 올라간다.
    private void OnTriggerEnter(Collider other)
    {
        // 단계1. 아이템을 먹었다면
        if (other.gameObject.tag == "Item")
        {
            // 단계2. 스킬레벨이 1 올라간다.
            if(skillLevel < 3)
                skillLevel++;

            // 단계3. 아이템을 파괴한다.
            Destroy(other.gameObject);
        }
    }
}