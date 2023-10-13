using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    Transform weapon;
    Transform target;
    // ���� ��� �ν� ����
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem weaponParticle;

    void Start()
    {
        weapon = transform;
        target = FindObjectOfType<EnemyMovement>().transform;
    }

    void Update()
    {
        FindClosestTarget();
        AimTarget();
    }
    
    // ���� ����� ���� Ÿ������ ����ǰ� �Ѵ�.
    private void FindClosestTarget()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        Transform clossest = null;
        float maxDistance = Mathf.Infinity;

        foreach (EnemyMovement enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(maxDistance > targetDistance)
            {
                clossest = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        if(clossest != null)
            target = clossest;
    }

    private void AimTarget()
    {
        // Target���� �Ÿ��� Range ���� ���, Attack(true) �ƴϸ� Attack(false)
        // Attack �Լ��� Emission�� �Ѱ� ���� �Լ�
        if (Vector3.Distance(transform.position, target.transform.position) < range)
            Attack(true);
        else
            Attack(false);
        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        var emission = weaponParticle.emission;
        emission.enabled = isActive;
    }
}
