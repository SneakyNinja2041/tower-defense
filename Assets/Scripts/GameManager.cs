using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool GameIsOver;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
