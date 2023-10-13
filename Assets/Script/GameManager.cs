using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{ 
    public TMP_Text scoreText;
    public GameObject gameOverUI; 

    int Score = 0;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void GameIsOver()
    {
        gameOverUI.SetActive(true);
    }

    public void UpdateScore()
    {
        Score += 10;
        scoreText.text = Score.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Exitbutton()
    {
        Application.Quit();
    }
}

