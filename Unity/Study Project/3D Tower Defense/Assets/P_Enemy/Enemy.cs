using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자산 관리
public class Enemy : MonoBehaviour
{
    [SerializeField] int rewardMoney = 25;
    [SerializeField] int panaltyMoney = 25;

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
