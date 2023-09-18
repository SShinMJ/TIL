using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f; // 소수점 6자리까지 표현
    [SerializeField] float moveSpeed = 10f;
    // double은 소수점 15자리 

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
