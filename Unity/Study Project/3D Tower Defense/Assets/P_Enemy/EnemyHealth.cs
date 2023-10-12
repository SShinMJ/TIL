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

    // 타워에서 발사되는 볼트는 파티클이므로, 파티클 충돌 함수를 사용한다.
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
