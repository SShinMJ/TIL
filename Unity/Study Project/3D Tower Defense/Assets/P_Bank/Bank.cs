using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Ÿ���� ��� ���� ���� �ý���.
// �ܾ� ����, �Ա�, ����
public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    [SerializeField] int startBalance = 150; // ù ���� �ݾ�
    [SerializeField] int currentBalance; // ���� �ݾ�

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
