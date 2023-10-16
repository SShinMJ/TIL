using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Tooltip("현재 금액 표시 Text UI")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("현재 적 스폰 남은 수 Text UI")]
    [SerializeField] TextMeshProUGUI enemyRemainingText;

    [Tooltip("레벨 종료 시 보여지는 UI 창")]
    [SerializeField] GameObject gameOverUI;
    [Tooltip("레밸 클리어 UI")]
    [SerializeField] GameObject gameClearText;
    [Tooltip("레밸 실패 UI")]
    [SerializeField] GameObject gameOverText;
    [Tooltip("스코어 Text UI")]
    [SerializeField] TextMeshProUGUI scoreText;
    [Tooltip("다음 레벨 씬으로 이동 Button UI")]
    [SerializeField] GameObject nextSceneBtn;
    [Tooltip("현재 씬 리로드 Button UI")]
    [SerializeField] GameObject reloadSceneBtn;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateBalanceText(int currentBalance)
    {
        balanceText.text = currentBalance.ToString();
    }

    public void UpdateEnemyRemainingText(int enemyRemaining)
    {
        enemyRemainingText.text = enemyRemaining.ToString();
    }

    public void GameClear()
    {
        // UI Active
        gameClearText.SetActive(true);
        gameOverText.SetActive(false);
        scoreText.text = balanceText.text;
        nextSceneBtn.SetActive(true);
        reloadSceneBtn.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void GameOver()
    {
        // UI Active
        gameClearText.SetActive(false);
        gameOverText.SetActive(true);
        scoreText.text = balanceText.text;
        nextSceneBtn.SetActive(false);
        reloadSceneBtn.SetActive(true);
        gameOverUI.SetActive(true);
    }

    public void LoadNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        try
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
        catch
        {
            return;
        }
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
