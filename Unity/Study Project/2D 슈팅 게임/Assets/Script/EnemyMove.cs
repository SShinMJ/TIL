using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : �Ʒ� �������� �̵��Ѵ�.
// ��ǥ2: �ٸ� �浹ü�� �ε����� ��븦 �ı��Ѵ�.
// ��ǥ3: �� ������Ʈ ���� ��, 30%�� Ȯ���� �÷��̾ ���󰣴�.
// �ʿ� : 30% Ȯ��
// ��ǥ4: 10%�� Ȯ���� �÷��̾ ���󰣴�.
// �ʿ� : �÷��̾��� ����
public class EnemyMove : MonoBehaviour
{
    // �ӵ�
    public float speed = 1.0f;
    // ����
    public Vector3 dir = Vector3.down;

    int randValue;
    GameObject player;
    // �÷��̾� ����
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

        // 50% ������ �� �� ������Ʈ ������ �÷��̾ �ȴ�.
        if (randValue < 5)
        {
            if (player != null)
            {
                // ���� �� ������ ��ǥ���� ���ָ� ����ǥ���� ������ �ȴ�.
                dir = player.transform.position - gameObject.transform.position;
                // ũ�Ⱑ 1�� ���ͷ� ����� �ش�.(��հ�)
                dir.Normalize();
            }
        }
    }

    void Update()
    {
        // 20% ������ �� ���� �÷��̾ ���󰡰� �Ѵ�.
        if (randValue < 3)
        {
            if (player != null)
            {
                playerDir = (player.transform.position - gameObject.transform.position).normalized;
                dir = playerDir;
            }
        }

        // ���� (������)�Ʒ��� ���ư���.
        transform.position += dir * speed * Time.deltaTime;
    }

    // OnCollisionEnter : �浹 ���� ����
    // OnCollisionStay : �浹 �߿� ����
    // OnCollisionExit : �浹 ����(���� ���� ������ �ʴ� ����) ����
    private void OnCollisionEnter(Collision otherObject)
    {
        // ȿ���� ���
        enemy_audio.Play();
        Debug.Log("Enemy Audio");

        // Destroy : ������Ʈ ����
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