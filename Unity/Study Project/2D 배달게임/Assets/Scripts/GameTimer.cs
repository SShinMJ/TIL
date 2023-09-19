using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float totalTime;
    [SerializeField] float finishTime = 300f;
    float remainingTime;

    [SerializeField] TMP_Text gameTimer;

    void Update()
    {
        totalTime += Time.deltaTime;
        remainingTime = finishTime - totalTime;

        string minutes = Mathf.Floor(remainingTime / 60).ToString("00");
        string seconds = (remainingTime % 60).ToString("00");
        gameTimer.text = string.Format("{0}:{1}", minutes, seconds);
        //gameTimer.text = string.Format("{0:N2}", remainingTime);

        if(remainingTime <= 0)
        {
            // 게임 종료.
            totalTime = 0;
            GameManager.instance.EndGame();
        }
    }
}
