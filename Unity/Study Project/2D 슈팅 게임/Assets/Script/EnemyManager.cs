using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ���� ���� �ð����� ����.
// �ʿ� : ���� �ð�, ���� �ð�, �� ������Ʈ
// ����1. ���� �ð����� ���� �ð��� �帣��,
// ����2. ���� EnemyManager ��ġ�� �����Ѵ�.

// �߰� : �� ���� �ֱ�(���� �ð�)�� ���� �ð����� �����Ѵ�.
public class EnemyManager : MonoBehaviour
{
    // Ư�� �ð�(default : 2��)
    float creatTime;
    // �� ���� �ð� �ּ�/�ִ�
    public int creatMinTime = 2;
    public int creatMaxTime = 5;
    // ���� �ð�
    float currentTime = 0;
    // �� ������Ʈ
    public GameObject Enemy;

    private void Start()
    {
        // �� ���� �ֱ�(���� �ð�)�� ���� �ð����� ����
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
            // 2. ���� EnemyManager ��ġ�� �����Ѵ�.
            GameObject EnemyObj = Instantiate(Enemy);
            EnemyObj.transform.position = transform.position;

            // ī��Ʈ �ð� �ʱ�ȭ
            currentTime = 0;
        }
    }
}