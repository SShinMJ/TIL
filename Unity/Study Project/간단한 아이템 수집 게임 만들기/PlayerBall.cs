using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public GameManagerLogic manager; 
    public float JumpForce = 20;
    public int itemCount = 0;
    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // w인 y축은 위 아래이므로 점프할 때 쓰인다.
        rigid.AddForce(new Vector3 (h, 0, v), ForceMode.Impulse);
    }
    
    // 충돌 이벤트 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 오브젝트를 구분하는 단순한 문자열(같은 역할을 하는 다양한 오브젝트의 이름을 통칭할 수 있다.)
        if (other.tag == "Item")
        {
            // PlayerBall의 점수값+1
            itemCount++;
            manager.GetItem(itemCount);

            // 효과음 재생
            audio.Play();

            // SetActive : 오브젝트 활성화 함수
            // 즉, player가 접촉하면 사라진다.
            other.gameObject.SetActive(false);
        }
        else if ( other.tag == "Goal")
        {
            // Find 계열 함수는 GPU를 사용한다. 
            // >> GameObject.FindGameObjectWithTag("Goal");
            // 따라서 부하를 초래할 수 있으므로 변수를 추가하여
            // Unity에서 해당 오브젝트를 변수에 넣어줄 수 있다.
            if(itemCount == manager.totalSocore)
            {
                // Game Clear
                // SceneManager : 장면을 관리하는 기본 클래스
                // LoadScene : 주어진 장면을 불러오는 함수(SampleScene : 프로젝트 이름)
                // 즉, 다른 씬으로 옮길 수 있다.
                SceneManager.LoadScene(manager.stage + 1);
                manager.stage++;
            }
            else
            {
                // Game restart
                // 현재 씬의 처음 상태로 복귀시킬 수도 있다.
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
