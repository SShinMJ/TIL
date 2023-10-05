using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// �� ��ũ��Ʈ�� ������ ������Ʈ�� Rigidbody2D�� �ݵ�� ������ �־����.
// �� ��ũ��Ʈ�� ���� Rigidbody�� �ڵ� �߰��ǰ� ������ �� ���� �ȴ�.
// ���� Rigidbody ������Ʈ�� �ڵ����� ����ȴ�.
public class PlayerController : MonoBehaviour
{
    // ������ ���� ǥ�� (���α׷� ��ü���� ���� ����)
    public static string gameState = "gameState";

    // �¿� �̵�
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    // ����
    public float jump = 8.0f;
    public LayerMask groundLayer;
    bool gojump = false;
    bool onGround = false;

    //�ִϸ��̼�
    Animator animator;
    public string[] Animations; // �ִϸ��̼� �̸�
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
        // Game Clear�� Over ���¶�� ���̻� �Է��� ���� �ʰ� �Ѵ�.
        if (gameState != "Playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal");

        // ���� ��ȯ
        // 1. Sprite Renderer�� Filp ��� Ȱ�� - üũ on/off
        // 2. Scale�� Ư���� �̿��� ������ȯ - x�� -1/1
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
            // �������� �ʴ� ����
            if(axisH == 0)
            {
                currentAnime = Animations[0]; 
            }
            else
            {
                currentAnime = Animations[1];
            }
        }
        // ���߿� �ִ� ���
        else
        {
            currentAnime = Animations[2];
        }

        // �ִϸ��̼��� �ٲ� ���
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
        // ����ĳ��Ʈ : ������ �� ���� �����ϴ� ������ ���� ���� ������Ʈ�� �����ϴ����� ���θ� üũ.
        // �÷��̾� ��ġ���� �÷��̾��� �Ʒ������� 0.1��ŭ���� line(��)�� ���� ��, Ground�� �����Ѵ�.
        // transform.up * 0.1f : ĳ���� �� ������ ���� ǥ��(Pivot)
        onGround = Physics2D.Linecast(transform.position, (transform.position - transform.up * 0.1f), groundLayer);

        rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        // ������ �õ����� ��, ���̶��
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
        // ��¦ �پ��ٰ� �Ʒ��� �������� ȿ�� �ֱ�
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        rbody.velocity = new Vector2(0, 0);
    }
}
