using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _sceneToload = "LevelSelect";

    [SerializeField] private string _firstLevelEasy = "Level 1 Easy";

    [SerializeField] private string _firstLevelDefault = "Level 1 Default";

    [SerializeField] private ScreenFade _screenFader;

 

    public void Play()
    {
        _screenFader.FadeTo(_sceneToload);

       

    }



    public void Quit()
    {
        Application.Quit();

    }

    public void PlayEasy()
    {
        _screenFader.FadeTo(_firstLevelEasy);
    }

    public void PlayStandart()
    {
        _screenFader.FadeTo(_firstLevelDefault);
    }



}
