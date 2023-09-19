using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    GameTimer timer;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score += value;
            ScoreText.text = score.ToString();
        }
    }
    public bool isPizza = false;
    private int deliveryCount = 0;
    public int DeliveryCount
    {
        get { return deliveryCount; }
        set
        {
            deliveryCount += value;
        }
    }

    [SerializeField] GameObject startUI;
    [SerializeField] GameObject inGameUI;

    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text GmaeTimeText;
    [SerializeField] Image pizzaStatusImg;
    [SerializeField] Sprite pizzaImg;
    [SerializeField] Sprite pizzaGrayScaleImg;

    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text endScoreText;
    [SerializeField] TMP_Text bestScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        timer = FindObjectOfType<GameTimer>();
        score = 0;
        ScoreText.text = score.ToString();
        deliveryCount = 0;
    }

    private void Update()
    {
        if(isPizza)
        {
            pizzaStatusImg.sprite = pizzaImg;
        }
        else
        {
            pizzaStatusImg.sprite = pizzaGrayScaleImg;
        }
    }

    public void GameStart()
    {
        startUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void deliveryDone(int revenue)
    {
        // 점수 올리기
        score += revenue;
        ScoreText.text = score.ToString();
        isPizza = false;
    }

    public void EndGame()
    {
        Time.timeScale = 0f;

        endScoreText.text = score.ToString();
        int bestScore = PlayerPrefs.GetInt("Best Score");
        if( score > bestScore )
        {
            bestScoreText.text = score.ToString();
            PlayerPrefs.SetInt("Best Score", score);
        }
        else
        {
            bestScoreText.text = bestScore.ToString();
        }

        gameOverUI.SetActive(true);
    }

    public void RetryGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
