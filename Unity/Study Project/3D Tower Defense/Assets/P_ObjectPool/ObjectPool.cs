using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("利 橇府普")]
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("积己秦 笛 橇府普 俺荐")]
    [SerializeField] int poolSize = 10;
    [Tooltip("利 积己 林扁")]
    [SerializeField] float spawnTime = 1f;
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