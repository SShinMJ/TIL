using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 4;
    int currentHp = 0;

    private void Start()
    {
        currentHp = maxHP;
    }

    // Ÿ������ �߻�Ǵ� ��Ʈ�� ��ƼŬ�̹Ƿ�, ��ƼŬ �浹 �Լ��� ����Ѵ�.
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 6)
        {
            Damaged();
        }
    }

    void Damaged()
    {
        currentHp--;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
