using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalSocore;
    public int stage;
    public Text stageCnt;
    public Text totalItemCnt;
    public Text playerItemCnt;

    private void Awake()
    {
        stageCnt.text = "Stage " + stage.ToString();
        totalItemCnt.text = "/ " + totalSocore.ToString();
    }
    public void GetItem(int count)
    {
        playerItemCnt.text = count.ToString();
    }

    // 아래로 떨어질 시 게임 제시작.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }
}
