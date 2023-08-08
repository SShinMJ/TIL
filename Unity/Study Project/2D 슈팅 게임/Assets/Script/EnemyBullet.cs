using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyBullet : MonoBehaviour
{
    // 속도
    public float speed = 1.0f;
    public Vector3 playerDir = Vector3.down;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerDir = (player.transform.position - gameObject.transform.position).normalized;
            // 머리가 향하는 방향 지정
            transform.rotation = Quaternion.LookRotation(playerDir);
            // Quaternion은 *가 더하기이다. 현재 백터에서 X에 90도를 더한다.
            transform.rotation *= Quaternion.Euler(90, 0, 0);
        }
    }

    private void Update()
    {
        // 총알이 플레이어에게 날아간다.
        transform.position += playerDir * speed * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision others)
    //{
    //    if (others.gameObject.tag == "Player")
    //    {
    //        Destroy(others.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}