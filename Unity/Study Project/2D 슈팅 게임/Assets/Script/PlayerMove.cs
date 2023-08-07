using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : �÷��̾ ����� �Է¿� ���� �����δ�.

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 playerPos = new Vector3 (0, 0, 0);
    Vector3 enemyPos = new Vector3(5, 5, 0);

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
}
