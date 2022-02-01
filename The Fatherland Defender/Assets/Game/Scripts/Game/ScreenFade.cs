using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScreenFade : MonoBehaviour
{

    [SerializeField] private Image _img;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }


    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    private IEnumerator FadeIn()
    {
        float a = 1;

        while(a > 0)
        {
            a -= Time.deltaTime;
            _img.color = new Color(0, 0, 0, a);
            yield return 0;

        }

    }

    private IEnumerator FadeOut(string scene)
    {
        float a = 0;

        while (a < 1)
        {
            a += Time.deltaTime;
            _img.color = new Color(0, 0, 0, a);
            yield return 0;
            SceneManager.LoadScene(scene);
        }

    }

}
