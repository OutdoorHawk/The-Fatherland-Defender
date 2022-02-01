using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcess : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _levelPassedUI;

    [SerializeField] private ScreenFade _screenFader;

    public static bool gameFinished;
    public static bool gamePaused;
    

    private void Start()
    {
        gameFinished = false;
        gamePaused = false;
        SetDefaultTimeScale();
        
    }

    void Update()
    {
        if (Stats.HealthPoints <=0 && !gameFinished)
        {
            LostGame();
        }
        if (Stats.HealthPoints > 0 && gameFinished)
        {
            WonGame();
        }
    }

    private void LostGame()
    {
        _gameOverUI.SetActive(true);
        gameFinished = true;
    }

    private void WonGame()
    {
        _levelPassedUI.SetActive(true);
        gameFinished = true;
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }


    public void Retry()
    {
        
        SetDefaultTimeScale();
        _screenFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        SetDefaultTimeScale();
    }

    public void MainMenu()
    {
        SetDefaultTimeScale();
        _screenFader.FadeTo("MainMenu");


    }

    public void SetDefaultTimeScale()
    {
        Time.timeScale = 1;
    }



}
