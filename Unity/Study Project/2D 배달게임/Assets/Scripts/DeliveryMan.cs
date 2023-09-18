using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f; // �Ҽ��� 6�ڸ����� ǥ��
    [SerializeField] float moveSpeed = 10f;
    // double�� �Ҽ��� 15�ڸ� 

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
