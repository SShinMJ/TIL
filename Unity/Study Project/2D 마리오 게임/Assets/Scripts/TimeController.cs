using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  게임 내에서 시간에 관련된 카운트 다운을 처리하기 위한 컨트롤러
/// </summary>
public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true일 경우 시간을 측정
    public float gameTime = 0; // 게임에 주어진 최대 시간
    public bool isTimeOver = false; // true일 경우 타이머 정지
    public float displayTime = 0; // 화면에 표시되는 시간
    float times = 0; // 현재 시간

    void Start()
    {
        if(isCountDown)
        {
            displayTime = gameTime;
        }
    }

    void Update()
    {
        if (isTimeOver == false)
        {
            if (isCountDown)
            {
                times += Time.deltaTime;
                displayTime = gameTime - times;
                if (displayTime <= 0.0f)
                {
                    displayTime = 0;
                    isTimeOver = true;
                }
            }
            else
            {
                displayTime = times;
                if (displayTime >= 0.0f)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }
            
        }
    }
}
