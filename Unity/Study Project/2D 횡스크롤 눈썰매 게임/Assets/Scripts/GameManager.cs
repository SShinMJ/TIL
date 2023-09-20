using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject goalInText;
    [SerializeField] GameObject gameOverText;

    [SerializeField] float loadDelay = 3f;

    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GoalIn()
    {
        if (!gameOverText.active)
        {
            Time.timeScale = 0.1f;
            audioSource.clip = audioClips[0];
            audioSource.Play();

            goalInText.SetActive(true);

            // �ش� �Լ��� 3�� �� ����
            Invoke("GameRestart", loadDelay);
        }
    }

    public void GameOver()
    {
        if (!goalInText.active)
        {
            Time.timeScale = 0.1f;

            audioSource.clip = audioClips[1];
            audioSource.Play();

            gameOverText.SetActive(true);

            FindFirstObjectByType<PlayerController>().DisableControls();

        // �ش� �Լ��� 3�� �� ����
        Invoke("GameRestart", loadDelay);
        }
    }

    void GameRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
