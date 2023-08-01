using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissleMovement : MonoBehaviour
{
    public float moveSpeed = 30.0f;

    private void Awake()
    {
        // 시간이 지나면 삭제
        Destroy(gameObject, 3.0f);
    }
    void Update()
    {
                                                        // 앞 방향,    세상 기준 (로컬기준(디폴트) Space.Self)
        transform.Translate(Time.deltaTime * moveSpeed * transform.up, Space.World);
                                                 // == * Vector3.up, Space.Self);
    }
}
