using UnityEngine;

// �ڻ� ����
[RequireComponent (typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [Tooltip("���� ��ġ���� �� ��� ���(1~50)")]
    [SerializeField] [Range(1, 50)] int rewardMoney = 25;
    [Tooltip("���� ��ġ���� ������ �� �Ҵ� ���(1~50)")]
    [SerializeField] [Range(1, 50)] int panaltyMoney = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // �� ��ü�� �׾��� ��
    public void RewardMoney()
    {
        bank.Deposit(rewardMoney);
    }

    // �� ��ü�� �����ʰ� ���� �������� ��
    public void PanaltyMoney()
    {
        bank.WithDraw(panaltyMoney);
    }
}
