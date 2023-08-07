using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 적 또는 총알이 감지될 때, 해당 물체를 삭제
public class DestoryZone : MonoBehaviour
{
    // Rigidbody에 is Trigger를 체크(true상태)로 해야한다.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Wall" && other.tag != "Player")
            Destroy(other.gameObject);
    }
}
