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
            // ��� �̻��� ���� ��ġ�� �̻����� ����
            foreach(GameObject obj in spawnPoints)
            {
                // �̻��� ������Ʈ ����
                newMissle = Instantiate(missle);
                // �̻��� ��ġ ����
                newMissle.transform.position = obj.transform.position;
                // �̻��� ���� ���� (world ����)
                newMissle.transform.rotation = obj.transform.rotation;
            }
        }
    }
}
