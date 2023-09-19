using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject pizza;
    public bool isPizza = false;

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
                pizza = collision.gameObject;
                pizza.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);

                GameManager.instance.isPizza = true;
            }
        }

        if (collision.tag == "Customer")
        {
            if (!isPizza)
            {
                Debug.Log("���ڸ� �������ּ���!");
            }
        }
    }
}
