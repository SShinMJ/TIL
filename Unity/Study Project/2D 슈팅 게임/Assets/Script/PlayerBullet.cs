using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : �Ѿ��� ����(������) ���ư��� �Ѵ�.
// �ʿ� : �Ѿ��� ����, �ӵ�.

// ��ǥ : �Ѿ��� ���� �浹�ϸ�, �Ѿ˰� ���� �����ȴ�.
public class PlayerBullet : MonoBehaviour
{
    // �ӵ�
    public float speed = 5.0f;
    // ����
    public Vector3 dir = Vector3.up;

    void Update()
    {
        // �Ѿ��� ����(������) ���ư���.
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