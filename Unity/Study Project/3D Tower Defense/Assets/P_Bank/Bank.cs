using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// 타워를 사기 위한 금전 시스템.
// 잔액 보관, 입금, 인출
public class Bank : MonoBehaviour
{
    [Tooltip("현재 금액 표시 Text UI")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("첫 시작 금액")]
    [SerializeField] [Range(0, 500)] int startBalance = 150;
    [Tooltip("현재 금액")]
    int currentBalance;

    // 외부에서 읽기만 가능하게 제한한다.
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startBalance;
        UpdateBalanceText();
    }

    private void UpdateBalanceText()
    {
        balanceText.text = "Gold : " + currentBalance.ToString();
    }

    // 입금
    public void Deposit(int amount)
    {
        // Mathf.Abs() : 절대값 변환 함수. 음수 값이 들어오는 것 방지.
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceText();
    }

    // 인출
    public void WithDraw(int amount)
    {
        currentBalance -= amount;
        UpdateBalanceText();

        if (currentBalance < 0)
        {
            Debug.Log("Game Over");
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
