using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZoneManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
        }
    }
}
