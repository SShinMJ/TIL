using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// 이 스크립트를 가지는 오브젝트는 Rigidbody2D를 반드시 가지고 있어야함.
// 이 스크립트로 인해 Rigidbody가 자동 추가되고 삭제할 수 없게 된다.
// 또한 Rigidbody 컴포넌트가 자동으로 연결된다.
public class PlayerController : MonoBehaviour
{
    // 게임의 상태 표시 (프로그램 전체에서 접근 가능)
    public static string gameState = "gameState";

    // 좌우 이동
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    // 점프
    public float jump = 8.0f;
    public LayerMask groundLayer;
    bool gojump = false;
    bool onGround = false;

    //애니메이션
    Animator animator;
    public string[] Animations; // 애니메이션 이름
    // 0 : PlayerIdle
    // 1 : PlayerRun
    // 2 : PlayerJump
    // 3 : PlayerOver
    // 4 : PlayerClear
    string currentAnime = "";
    string prevAnime = "";

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        currentAnime = Animations[0];
        prevAnime = Animations[0];
    }

    void Update()
    {
        // Game Clear나 Over 상태라면 더이상 입력을 받지 않게 한다.
        if (gameState != "Playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal");

        // 방향 전환
        // 1. Sprite Renderer의 Filp 기능 활용 - 체크 on/off
        // 2. Scale의 특성을 이용한 방향전환 - x값 -1/1
        if(axisH >= 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(onGround)
        {
            // 움직이지 않는 상태
            if(axisH == 0)
            {
                currentAnime = Animations[0]; 
            }
            else
            {
                currentAnime = Animations[1];
            }
        }
        // 공중에 있는 경우
        else
        {
            currentAnime = Animations[2];
        }

        // 애니메이션이 바뀐 경우
        if(currentAnime != prevAnime)
        {
            prevAnime = currentAnime;
            animator.Play(currentAnime);
        }
    }

    private void Jump()
    {
        gojump = true;
    }

    private void FixedUpdate()
    {
        // 라인캐스트 : 지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접속하는지의 여부를 체크.
        // 플레이어 위치에서 플레이어의 아래쪽으로 0.1만큼으로 line(선)를 쐈을 때, Ground만 검출한다.
        // transform.up * 0.1f : 캐릭터 발 지점에 대한 표현(Pivot)
        onGround = Physics2D.Linecast(transform.position, (transform.position - transform.up * 0.1f), groundLayer);

        rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        // 점프를 시도했을 때, 땅이라면
        if(gojump && onGround)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            gojump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    private void Goal()
    {
        animator.Play(Animations[4]);
        gameState = "Game Clear";
        GameStop();
    }

    public void GameOver()
    {
        animator.Play(Animations[3]);
        GameStop();
        gameState = "Game Over";
        // 살짝 뛰었다가 아래로 떨어지는 효과 주기
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        rbody.velocity = new Vector2(0, 0);
    }
}
