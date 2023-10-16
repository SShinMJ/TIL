using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("�� ������")]
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("������ �� ������ ����(0~50��)")]
    [SerializeField] [Range(0, 50)] int poolSize = 10;
    [Tooltip("�� ���� �ֱ�(0.1~20��)")]
    [SerializeField][Range(0.1f, 20)] float spawnTime = 1f;
    GameObject[] pool;
    [Tooltip("���������� �� ����(0~100��)")]
    [SerializeField][Range(1, 1000)] int totalEnemyCount = 50;
    int enemyRemaining;

    void Awake()
    {
        CreatePool();
        enemyRemaining = totalEnemyCount;
        GameManager.Instance.UpdateEnemyRemainingText(enemyRemaining);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void CreatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                enemyRemaining--;
                UpdateEnemyRemaining();
                return;
            }
        }
    }

    private void UpdateEnemyRemaining()
    {
        GameManager.Instance.UpdateEnemyRemainingText(enemyRemaining);

        if (enemyRemaining <= 0)
        {
            // �� ���� ���߱� ���� ������ �ڵ�
            spawnTime = Mathf.Infinity;
            // ��� �� ��ü�� ��Ȱ��ȭ �ƴ� �� Ȯ��
            StartCoroutine(CheckGameOver());
        }
    }

    IEnumerator CheckGameOver()
    {
        while (true)
        {
            CheckEnemyActive();

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void CheckEnemyActive()
    {
        bool allnotActive = false;
        for (int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeInHierarchy == true)
            {
                break;
            }
            if (i == poolSize - 1)
                allnotActive = true;
        }

        if (allnotActive)
        {
            // ���� Ŭ���� �� ���� �������� �̵�
            GameManager.Instance.GameClear();
        }
    }
}