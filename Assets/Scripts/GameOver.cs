using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();

    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
