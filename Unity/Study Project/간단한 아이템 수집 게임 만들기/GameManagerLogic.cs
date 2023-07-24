using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// GameManager 클래스는 일반적으로 게임의 진행을 위한 상태 정보 및 게임 외적의 기능을 처리하는 기능들을 담는다.
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

    // 아래로 떨어질 시 게임 재시작.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }
}
