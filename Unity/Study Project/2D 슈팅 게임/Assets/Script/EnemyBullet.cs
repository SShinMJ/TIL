using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyBullet : MonoBehaviour
{
    // �ӵ�
    public float speed = 1.0f;
    public Vector3 playerDir = Vector3.down;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerDir = (player.transform.position - gameObject.transform.position).normalized;
            // �Ӹ��� ���ϴ� ���� ����
            transform.rotation = Quaternion.LookRotation(playerDir);
            // Quaternion�� *�� ���ϱ��̴�. ���� ���Ϳ��� X�� 90���� ���Ѵ�.
            transform.rotation *= Quaternion.Euler(90, 0, 0);
        }
    }

    private void Update()
    {
        // �Ѿ��� �÷��̾�� ���ư���.
        transform.position += playerDir * speed * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision others)
    //{
    //    if (others.gameObject.tag == "Player")
    //    {
    //        Destroy(others.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}