using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float moveSpeed = 10.0f;
    public float rotateSpeed = 30.0f;

    void Update()
    {
        // ����
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
        }

        // ȸ��
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.back);
        }
    }
}
