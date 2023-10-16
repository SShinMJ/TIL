using UnityEngine;

// 타워를 사기 위한 금전 시스템.
// 잔액 보관, 입금, 인출
public class Bank : MonoBehaviour
{
    [Tooltip("첫 시작 금액")]
    [SerializeField] [Range(0, 500)] int startBalance = 150;
    [Tooltip("현재 금액")]
    int currentBalance;

    // 외부에서 읽기만 가능하게 제한한다.
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startBalance;
    }

    private void Start()
    {
        GameManager.Instance.UpdateBalanceText(currentBalance);
    }

    // 입금
    public void Deposit(int amount)
    {
        // Mathf.Abs() : 절대값 변환 함수. 음수 값이 들어오는 것 방지.
        currentBalance += Mathf.Abs(amount);
        GameManager.Instance.UpdateBalanceText(currentBalance);
    }

    // 인출
    public void WithDraw(int amount)
    {
        currentBalance -= amount;
        GameManager.Instance.UpdateBalanceText(currentBalance);

        if (currentBalance < 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
