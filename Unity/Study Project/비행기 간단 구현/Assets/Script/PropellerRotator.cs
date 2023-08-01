using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotator : MonoBehaviour
{
    public float rotationSpeed = 7200.0f;
    void Update()
    {
        transform.Rotate(Vector3.forward *  Time.deltaTime * rotationSpeed);
    }
}
