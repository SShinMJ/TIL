using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // Ư�� �ð�(default : 2��)
    float creatTime;
    // �� �Ѿ� ���� �ð� �ּ�/�ִ�
    public int creatMinTime = 2;
    public int creatMaxTime = 10;
    // ���� �ð�
    float currentTime = 0;
    // �� ������Ʈ
    public GameObject Bullet;
    private void Start()
    {
        // ���� �Ѿ� ���� �ֱ�(���� �ð�)�� ���� �ð����� ����
        creatTime = Random.Range(creatMinTime, creatMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �帥��.
        currentTime += Time.deltaTime;
        // 1. ���� �ð� �̻� ���� �� ����
        if (currentTime >= creatTime)
        {
            // �Ѿ��� ���� (Instantiate)
            GameObject bulletObject = Instantiate(Bullet);

            // �Ѿ��� ���� ��ġ�� ����
            bulletObject.transform.position = transform.position;

            // ī��Ʈ �ð� �ʱ�ȭ
            currentTime = 0;
        }
    }
}