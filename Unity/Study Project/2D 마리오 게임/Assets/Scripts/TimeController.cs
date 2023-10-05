using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ���� ������ �ð��� ���õ� ī��Ʈ �ٿ��� ó���ϱ� ���� ��Ʈ�ѷ�
/// </summary>
public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true�� ��� �ð��� ����
    public float gameTime = 0; // ���ӿ� �־��� �ִ� �ð�
    public bool isTimeOver = false; // true�� ��� Ÿ�̸� ����
    public float displayTime = 0; // ȭ�鿡 ǥ�õǴ� �ð�
    float times = 0; // ���� �ð�

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
