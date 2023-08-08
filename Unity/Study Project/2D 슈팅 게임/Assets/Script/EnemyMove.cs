using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 아래 방향으로 이동한다.
// 목표2: 다른 충돌체와 부딪히면 상대를 파괴한다.
// 목표3: 적 오브젝트 생성 시, 30%의 확률로 플레이어를 따라간다.
// 필요 : 30% 확률
// 목표4: 10%의 확률로 플레이어를 따라간다.
// 필요 : 플레이어의 방향
public class EnemyMove : MonoBehaviour
{
    // 속도
    public float speed = 1.0f;
    // 방향
    public Vector3 dir = Vector3.down;

    int randValue;
    GameObject player;
    // 플레이어 방향
    Vector3 playerDir;

    public GameObject p_explosionEffect;
    public GameObject e_explosionEffect;

    AudioSource enemy_audio;

    private void Awake()
    {
        enemy_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        randValue = Random.Range(0, 10);
        player = GameObject.FindGameObjectWithTag("Player");

        // 50% 이하일 시 적 오브젝트 방향이 플레이어가 된다.
        if (randValue < 5)
        {
            if (player != null)
            {
                // 점과 점 사이의 좌표값을 빼주면 앞좌표로의 방향이 된다.
                dir = player.transform.position - gameObject.transform.position;
                // 크기가 1인 벡터로 만들어 준다.(평균값)
                dir.Normalize();
            }
        }
    }

    void Update()
    {
        // 20% 이하일 시 적이 플레이어를 따라가게 한다.
        if (randValue < 3)
        {
            if (player != null)
            {
                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                dir = playerDir;
            }
        }

        // 적이 (위에서)아래로 날아간다.
        transform.position += dir * speed * Time.deltaTime;
    }

    // OnCollisionEnter : 충돌 순간 실행
    // OnCollisionStay : 충돌 중에 실행
    // OnCollisionExit : 충돌 직후(점과 점이 만나지 않는 순간) 실행
    private void OnCollisionEnter(Collision otherObject)
    {
        // 효과음 재생
        enemy_audio.Play();
        Debug.Log("Enemy Audio");

        // Destroy : 오브젝트 삭제
        if (otherObject.gameObject.layer == 7)
        {
            GameObject PlayerBulletExplosion = Instantiate(p_explosionEffect);
            PlayerBulletExplosion.transform.position = otherObject.transform.position;
            Destroy(otherObject.gameObject);

            GameObject EnemyExplosion = Instantiate(e_explosionEffect);
            EnemyExplosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}