using UnityEngine;

// 자산 관리
[RequireComponent (typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [Tooltip("적을 해치웠을 때 얻는 비용(1~50)")]
    [SerializeField] [Range(1, 50)] int rewardMoney = 25;
    [Tooltip("적을 해치우지 못했을 때 잃는 비용(1~50)")]
    [SerializeField] [Range(1, 50)] int panaltyMoney = 25;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // 적 개체가 죽었을 시
    public void RewardMoney()
    {
        bank.Deposit(rewardMoney);
    }

    // 적 개체가 죽지않고 끝에 도달했을 시
    public void PanaltyMoney()
    {
        bank.WithDraw(panaltyMoney);
    }
}
