using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : �� �Ǵ� �Ѿ��� ������ ��, �ش� ��ü�� ����
public class DestroyZone : MonoBehaviour
{
    // Rigidbody�� is Trigger�� üũ(true����)�� �ؾ��Ѵ�.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "DestroyZone" && other.tag != "Player")
            Destroy(other.gameObject);
    }
}