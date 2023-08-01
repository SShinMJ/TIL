using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissleMovement : MonoBehaviour
{
    public float moveSpeed = 30.0f;

    private void Awake()
    {
        // �ð��� ������ ����
        Destroy(gameObject, 3.0f);
    }
    void Update()
    {
                                                        // �� ����,    ���� ���� (���ñ���(����Ʈ) Space.Self)
        transform.Translate(Time.deltaTime * moveSpeed * transform.up, Space.World);
                                                 // == * Vector3.up, Space.Self);
    }
}
