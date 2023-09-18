using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool isPizza = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "�� �浹��!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PickupItem")
        {
            if(isPizza)
            {
                Debug.Log("�̹� ���ڰ� �־��!");
            }
            else
            {
                Debug.Log("���� ��� ����~");
                isPizza = true;
            }
        }

        if (collision.tag == "Customer")
        {
            if (isPizza)
            {
                Debug.Log("��� �Ϸ�!~");
                isPizza = false;
            }
            else
            {
                Debug.Log("���ڸ� �������ּ���!");
            }
        }
    }
}
