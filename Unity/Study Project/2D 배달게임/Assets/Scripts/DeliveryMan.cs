using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f; // 소수점 6자리까지 표현, double은 소수점 15자리 
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

            // 2초 후 속도 정상화
            Invoke("ResetSpeed", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed *= slowAmount;

        // 2초 후 속도 정상화
        Invoke("ResetSpeed", 2f);
    }

    // 일정 시간이 지나면 스피드 리셋
    private void ResetSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
