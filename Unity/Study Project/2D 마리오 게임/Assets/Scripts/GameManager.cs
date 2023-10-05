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

    // �ð� ���� ���� ��� �߰�
    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeController;

    private void Start()
    {
        timeController = GetComponent<TimeController>();
        if(timeController != null)
        {
            // �ð� ������ ���� ��� Ÿ�ӹ� ������Ʈ�� �����.
            if(timeController.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }

        // Invoke : �Լ��̸�, �ð� �ְ� �� �ð� ���� �Լ��� �����ϰ� �Ѵ�.
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
            // Restart ��ư ��Ȱ��ȭ (�̹� �����Ƿ�)
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
            // Next ��ư ��Ȱ��ȭ (���� ���������� �������Ƿ�)
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
