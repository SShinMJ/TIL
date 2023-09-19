using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f; // �Ҽ��� 6�ڸ����� ǥ��, double�� �Ҽ��� 15�ڸ� 
    [SerializeField] float defaultMoveSpeed = 10f;
    float moveSpeed;
    [SerializeField] float boostAmout = 2f;
    [SerializeField] float slowAmount = 0.5f;

    private void Start()
    {
        moveSpeed = defaultMoveSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        steerAmount = (moveAmount == 0) ? 0 : (moveAmount >= 0 ? -steerAmount : steerAmount);

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Booster")
        {
            moveSpeed *= boostAmout;

            // 2�� �� �ӵ� ����ȭ
            Invoke("ResetSpeed", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed *= slowAmount;

        // 2�� �� �ӵ� ����ȭ
        Invoke("ResetSpeed", 2f);
    }

    // ���� �ð��� ������ ���ǵ� ����
    private void ResetSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
