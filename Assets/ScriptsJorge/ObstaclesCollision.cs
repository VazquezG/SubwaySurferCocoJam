using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
