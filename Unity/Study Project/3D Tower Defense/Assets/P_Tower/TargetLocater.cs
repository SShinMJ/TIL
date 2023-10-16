using UnityEngine;

[RequireComponent (typeof(Tower))]
public class TargetLocater : MonoBehaviour
{
    Transform weapon;
    Transform target;
    [Tooltip("공격 대상 인식 범위")]
    [SerializeField] [Range(0.1f, 50)] float range = 15f;
    [Tooltip("타워가 발사할 파티클")]
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
    
    // 가장 가까운 적을 타겟으로 변경되게 한다.
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
        // Target과의 거리가 Range 내에 들면, Attack(true) 아니면 Attack(false)
        // Attack 함수는 Emission을 켜고 끄는 함수
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
