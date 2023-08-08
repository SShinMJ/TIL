using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : �÷��̾ ����� �Է¿� ���� �����δ�.

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 playerPos = new Vector3(0, 0, 0);
    Vector3 enemyPos = new Vector3(5, 5, 0);

    public int playerHp = 3;
    public GameObject p_explosionEffect;
    public GameObject e_explosionEffect;

    AudioSource player_audio;

    private void Awake()
    {
        player_audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        // ���� ���� ���� ����(�ﰢ���� �����ϱ�� ����)
        Vector3 direction = enemyPos - playerPos;
        // magnitude : ������ ���� ���
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
        //                         ������ġ + ���� * �ӵ� * ������ �ӵ� ���߱�(���� �������� ���ǵ� ������ �ӵ�)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            playerHp--;

            GameObject EnemyExplosion = Instantiate(e_explosionEffect);
            EnemyExplosion.transform.position = collision.transform.position;
            Destroy(collision.gameObject);

            if (playerHp <= 0)
            {
                GameObject playerExplosion = Instantiate(p_explosionEffect);
                playerExplosion.transform.position = transform.position;

                // ȿ���� ���
                player_audio.Play();

                Destroy(gameObject);
            }
        }
    }
}