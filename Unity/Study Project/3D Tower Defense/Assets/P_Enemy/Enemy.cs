using UnityEngine;

// �ڻ� ����
public class Enemy : MonoBehaviour
{
    [Tooltip("���� ��ġ���� �� ��� ���")]
    [SerializeField] int rewardMoney = 25;
    [Tooltip("���� ��ġ���� ������ �� �Ҵ� ���")]
    [SerializeField] int panaltyMoney = 25;

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
