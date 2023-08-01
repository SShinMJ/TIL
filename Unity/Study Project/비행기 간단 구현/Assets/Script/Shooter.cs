using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject missle;
    public GameObject[] spawnPoints;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("MissleSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newMissle;
            // 모든 미사일 생성 위치에 미사일을 생성
            foreach(GameObject obj in spawnPoints)
            {
                // 미사일 오브젝트 생성
                newMissle = Instantiate(missle);
                // 미사일 위치 생성
                newMissle.transform.position = obj.transform.position;
                // 미사일 방향 지정 (world 기준)
                newMissle.transform.rotation = obj.transform.rotation;
            }
        }
    }
}
