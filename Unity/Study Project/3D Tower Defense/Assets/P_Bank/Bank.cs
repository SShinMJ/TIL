using UnityEngine;

// Ÿ���� ��� ���� ���� �ý���.
// �ܾ� ����, �Ա�, ����
public class Bank : MonoBehaviour
{
    [Tooltip("ù ���� �ݾ�")]
    [SerializeField] [Range(0, 500)] int startBalance = 150;
    [Tooltip("���� �ݾ�")]
    int currentBalance;

    // �ܺο��� �б⸸ �����ϰ� �����Ѵ�.
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startBalance;
    }

    private void Start()
    {
        GameManager.Instance.UpdateBalanceText(currentBalance);
    }

    // �Ա�
    public void Deposit(int amount)
    {
        // Mathf.Abs() : ���밪 ��ȯ �Լ�. ���� ���� ������ �� ����.
        currentBalance += Mathf.Abs(amount);
        GameManager.Instance.UpdateBalanceText(currentBalance);
    }

    // ����
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
