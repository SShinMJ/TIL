using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    void Awake()
    {
        // FindGameObjectWithTag : 주어진 태그로 오브젝트 검색
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // 오프셋을 현재 카메라와 player위치와의 간격으로 둔다.
        // (미리 카메라를 적정 위치에 이동시켜 놓아야 한다.)
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // player에게서 일정 거리 떨어진채로 따라와야한다.
        // 이를 오프셋을 두어 구현할 수 있다.
        transform.position = playerTransform.position + offset;
    }
}
