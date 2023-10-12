using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    Transform weapon;
    Transform target;

    void Start()
    {
        weapon = transform;
        target = FindObjectOfType<EnemyMovement>().transform;
    }

    void Update()
    {
        AimTarget();
    }

    private void AimTarget()
    {
        weapon.LookAt(target);
    }
}
