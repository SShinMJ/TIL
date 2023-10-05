using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSprite;
    public Sprite gameClearSprite;
    public GameObject panel;
    public GameObject restratBtn;
    public GameObject nextBtn;

    Image titleImage;

    // 시간 제한 관련 기능 추가
    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeController;

    private void Start()
    {
        timeController = GetComponent<TimeController>();
        if(timeController != null)
        {
            // 시간 제한이 없는 경우 타임바 오브젝트를 숨긴다.
            if(timeController.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }

        // Invoke : 함수이름, 시간 넣고 그 시간 이후 함수를 실행하게 한다.
        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);
    }

    private void Update()
    {
        if(PlayerController.gameState == "Game Clear")
        {
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            mainImage.SetActive(true);
            panel.SetActive(true);
            // Restart 버튼 비활성화 (이미 깼으므로)
            restratBtn.GetComponent<Button>().interactable = false;
            PlayerController.gameState = "Game End";

            if(timeController != null)
            {
                timeController.isTimeOver = true;
            }
        }
        else if(PlayerController.gameState == "Game Over")
        {
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            mainImage.SetActive(true);
            panel.SetActive(true);
            // Next 버튼 비활성화 (현재 스테이지를 못깼으므로)
            nextBtn.GetComponent<Button>().interactable = false;
            PlayerController.gameState = "Game End";

            if (timeController != null)
            {
                timeController.isTimeOver = true;
            }
        }
        else if (PlayerController.gameState == "Playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();

            if(timeController != null)
            {
                if(timeController.gameTime > 0.0f)
                {
                    int time = (int)timeController.displayTime;
                    string minutes = Mathf.Floor(time / 60).ToString("00");
                    string seconds = (time % 60).ToString("00");
                    timeText.GetComponent<TextMeshProUGUI>().text = string.Format("{0}:{1}", minutes, seconds); ;

                    if(time == 0)
                    {
                        playerController.GameOver();
                    }
                }
            }
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
        PlayerController.gameState = "Playing";
    }
}
