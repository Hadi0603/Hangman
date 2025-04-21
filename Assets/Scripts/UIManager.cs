using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[SerializeField] private float gameTime = 60f;
    //private bool isBlinking = false;
    //private bool isPaused = false;
    //[SerializeField] private Text timerText;
    [FormerlySerializedAs("gameOverUI")] [SerializeField] private GameObject levelWonUI;
    [SerializeField] private GameObject levelLostUI;
    //[SerializeField] GameObject pauseUI;
    [SerializeField] QuizController quizController;

    private void Awake()
    {
        Time.timeScale = 1f;
        //StartCoroutine(TimerCountdown());
    }

    /*private IEnumerator TimerCountdown()
    {
        while (gameTime > 0)
        {
            if (!isPaused)
            {
                gameTime -= Time.deltaTime;
                UpdateTimerDisplay();

                if (gameTime <= 15f && !isBlinking)
                {
                    StartCoroutine(BlinkTimer());
                }
            }
            yield return null;
        }

        GameOver();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private IEnumerator BlinkTimer()
    {
        isBlinking = true;
        Color originalColor = timerText.color;
    
        while (gameTime <= 15f && gameTime > 0)
        {
            timerText.color = (timerText.color == Color.red) ? Color.white : Color.red;
            yield return new WaitForSeconds(0.5f);
        }

        timerText.color = originalColor;
        isBlinking = false;
    }

    public void OpenPauseMenu()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }*/
    public void TriggerGameWon()
    {
        levelWonUI.SetActive(true);
        if (GameController.levelToLoad < 15)
        {
            PlayerPrefs.SetInt("levelToLoad", ++GameController.levelToLoad);
        }
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        levelLostUI.SetActive(true);
    }

}
