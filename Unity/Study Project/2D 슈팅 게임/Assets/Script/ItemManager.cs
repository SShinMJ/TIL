using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표1 : 스킬아이템을 특정시간마다 만든다.
//필요  : 스킬아이템, 특정 랜덤 시간(최소시간, 최대시간), 현재시간

//단계1.시간이 흐른다
//단계2. 현재시간이 특정 랜덤 시간(최소시간, 최대시간)을 넘으면
//단계3. 스킬아이템을 생성한다.
//단계4. 스킬아이템 위치를 스킬매니저의 위치로 설정한다.
//단계5. 시간을 다시 설정해준다.
public class ItemManager : MonoBehaviour
{
    public GameObject item;

    float creatTime;
    public float minCreateTime;
    public float maxCreateTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        // 랜덤으로 스폰 시간을 설정한다.
        creatTime = Random.Range(minCreateTime, maxCreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐른다. 일정 시간 탐색
        currentTime += Time.deltaTime;

        if (currentTime > creatTime)
        {
            // 아이템 오브젝트 생성
            GameObject skillItem = Instantiate(item);
            // 스폰 위치 설정
            skillItem.transform.position = transform.position;

            currentTime = 0;

            // 시간 재설정
            creatTime = Random.Range(minCreateTime, maxCreateTime);
        }
    }
}
