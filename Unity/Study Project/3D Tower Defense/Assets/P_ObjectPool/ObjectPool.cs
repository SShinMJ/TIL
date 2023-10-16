using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("적 프리팹")]
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("생성해 둘 프리팹 개수(0~50개)")]
    [SerializeField] [Range(0, 50)] int poolSize = 10;
    [Tooltip("적 생성 주기(0.1~20초)")]
    [SerializeField][Range(0.1f, 20)] float spawnTime = 1f;
    GameObject[] pool;
    [Tooltip("스테이지의 적 개수(0~100개)")]
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
            // 적 생성 멈추기 위한 딜레이 코드
            spawnTime = Mathf.Infinity;
            // 모든 적 개체가 비활성화 됐는 지 확인
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
            // 게임 클리어 및 다음 스테이지 이동
            GameManager.Instance.GameClear();
        }
    }
}