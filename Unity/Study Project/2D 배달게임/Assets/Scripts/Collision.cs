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
                Debug.Log("이미 피자가 있어요!");
            }
            else
            {
                Debug.Log("피자 배달 시작~");
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
                Debug.Log("피자를 가져와주세요!");
            }
        }
    }
}
