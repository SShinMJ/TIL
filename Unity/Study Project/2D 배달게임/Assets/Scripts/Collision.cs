using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool isPizza = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "와 충돌함!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PickupItem")
        {
            if(isPizza)
            {
                Debug.Log("이미 피자가 있어요!");
            }
            else
            {
                Debug.Log("피자 배달 시작~");
                isPizza = true;
            }
        }

        if (collision.tag == "Customer")
        {
            if (isPizza)
            {
                Debug.Log("배달 완료!~");
                isPizza = false;
            }
            else
            {
                Debug.Log("피자를 가져와주세요!");
            }
        }
    }
}
