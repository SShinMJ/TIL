using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    [Tooltip("적의 HP(1~50)")] 
    [SerializeField] [Range(1, 50)] int maxHP = 4;
    [Tooltip("적의 체력 추가 정도(1~50)")]
    [SerializeField] [Range(1, 50)] int difficultyInscrese = 1;
    int currentHp = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

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
            gameObject.SetActive(false);
            maxHP += difficultyInscrese;
            enemy.RewardMoney();
        }
    }
}
