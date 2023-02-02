using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject credits;
    public int target = 30;
    public string nextSceneName;

    void Start()
    {
        QualitySettings.vSyncCount = 0;

        mainCanvas.SetActive(true);
        credits.SetActive(false);
    }

    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void goCredits()
    {
        credits.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void back()
    {
        credits.SetActive(false);
        mainCanvas.SetActive(true);
    }




}
