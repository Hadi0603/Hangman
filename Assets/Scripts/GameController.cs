using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int levelToLoad;
    public UIManager uiManager;
    private void Start()
    {
        levelToLoad = PlayerPrefs.GetInt("levelToLoad", 1);
    }

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseBtn()
    {
        uiManager.OpenPauseMenu();
    }

    public void ResumeBtn()
    {
        uiManager.ClosePauseMenu();
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void ClearBtn()
    {
        PlayerPrefs.DeleteAll();
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
