using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Tooltip("���� �ݾ� ǥ�� Text UI")]
    [SerializeField] TextMeshProUGUI balanceText;
    [Tooltip("���� �� ���� ���� �� Text UI")]
    [SerializeField] TextMeshProUGUI enemyRemainingText;

    [Tooltip("���� ���� �� �������� UI â")]
    [SerializeField] GameObject gameOverUI;
    [Tooltip("���� Ŭ���� UI")]
    [SerializeField] GameObject gameClearText;
    [Tooltip("���� ���� UI")]
    [SerializeField] GameObject gameOverText;
    [Tooltip("���ھ� Text UI")]
    [SerializeField] TextMeshProUGUI scoreText;
    [Tooltip("���� ���� ������ �̵� Button UI")]
    [SerializeField] GameObject nextSceneBtn;
    [Tooltip("���� �� ���ε� Button UI")]
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
