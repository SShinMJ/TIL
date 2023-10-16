using System;
using System.Collections;
using System.Collections.Generic;
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

    void Awake()
    {
        CreatePool();
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
                return;
            }
        }
    }
}