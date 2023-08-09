using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표2: 스킬아이템이 아래방향으로 특정속도로 이동한다.
//필요 : 아래 방향, 특정속도
//목표3: 스킬이 파괴될 때 아이템 이펙트를 생성한다.
//필요 : 아이템 이펙트 

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
        // 아이템이 아래 방향으로 내려간다.
        transform.position += itemDirection * itemSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        // 아이템이 Destroy될 때 이팩트가 생성된다.
        GameObject itemGet = Instantiate(itemEffect);
        itemGet.transform.position = transform.position;

        // 효과음 재생
        item_audio.Play();
    }
}
