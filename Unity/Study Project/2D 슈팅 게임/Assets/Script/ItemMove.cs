using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ2: ��ų�������� �Ʒ��������� Ư���ӵ��� �̵��Ѵ�.
//�ʿ� : �Ʒ� ����, Ư���ӵ�
//��ǥ3: ��ų�� �ı��� �� ������ ����Ʈ�� �����Ѵ�.
//�ʿ� : ������ ����Ʈ 

public class ItemMove : MonoBehaviour
{
    Vector3 itemDirection = Vector3.down;
    public float itemSpeed = 2.0f;

    public GameObject itemEffect;

    AudioSource item_audio;

    private void Awake()
    {
        item_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �������� �Ʒ� �������� ��������.
        transform.position += itemDirection * itemSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        // �������� Destroy�� �� ����Ʈ�� �����ȴ�.
        GameObject itemGet = Instantiate(itemEffect);
        itemGet.transform.position = transform.position;

        // ȿ���� ���
        item_audio.Play();
    }
}
