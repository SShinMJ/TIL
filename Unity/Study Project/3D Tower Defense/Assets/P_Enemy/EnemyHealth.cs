using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    [Tooltip("���� HP")] 
    [SerializeField] int maxHP = 4;
    [Tooltip("���� ü�� �߰� ����")]
    [SerializeField] int difficultyInscrese = 1;
    int currentHp = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();

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
            gameObject.SetActive(false);
            maxHP += difficultyInscrese;
            enemy.RewardMoney();
        }
    }
}
