using UnityEngine;

public class Customer : MonoBehaviour
{
    bool isDelivery = false;

    float currentTime = 0;
    float orderTime;
    [SerializeField] int orderMinTime = 3;
    [SerializeField] int orderMaxTime = 15;
    [SerializeField] float orderLimitTime = 30f;
    [SerializeField] int revenue = 100;
    [SerializeField] int lossAmount = 10;

    void Start()
    {
        orderTime = Random.Range(orderMinTime, orderMaxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= orderTime && !isDelivery && GameManager.instance.DeliveryCount < 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isDelivery = true;

            GameManager.instance.DeliveryCount = 1;
            currentTime = 0;
        }

        // 시간내에 배달 실패 시.
        if (currentTime >= orderLimitTime && isDelivery)
        {
            // 점수 줄어들기
            if (GameManager.instance.Score >= lossAmount)
                GameManager.instance.Score = -lossAmount;
            else
                GameManager.instance.Score = -GameManager.instance.Score;

            GameManager.instance.DeliveryCount = -1;
            transform.GetChild(0).gameObject.SetActive(false);
            isDelivery = false;
            currentTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // 플레이어가 피자를 가지고 있다면 배달 완료.
            if (GameManager.instance.isPizza)
            {
                GameManager.instance.deliveryDone(revenue);

                Debug.Log("배달 완료!~");
                collision.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                collision.GetComponent<Collision>().isPizza = false;
                collision.GetComponent<Collision>().pizza.SetActive(true);

                GameManager.instance.DeliveryCount = -1;
                transform.GetChild(0).gameObject.SetActive(false);
                isDelivery = false;
                currentTime = 0;
            }
        }
    }
}
