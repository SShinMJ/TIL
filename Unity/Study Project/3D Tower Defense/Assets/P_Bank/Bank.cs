using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ÿ���� ��� ���� ���� �ý���.
// �ܾ� ����, �Ա�, ����
public class Bank : MonoBehaviour
{
    [Tooltip("���� �ݾ� ǥ�� Text UI")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("ù ���� �ݾ�")]
    [SerializeField] [Range(0, 500)] int startBalance = 150;
    [Tooltip("���� �ݾ�")]
    int currentBalance;

    // �ܺο��� �б⸸ �����ϰ� �����Ѵ�.
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

    // �Ա�
    public void Deposit(int amount)
    {
        // Mathf.Abs() : ���밪 ��ȯ �Լ�. ���� ���� ������ �� ����.
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceText();
    }

    // ����
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
