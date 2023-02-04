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
    public GameObject dunya1;
    public GameObject dunya2;

    void Start()
    {
        QualitySettings.vSyncCount = 0;

        mainCanvas.SetActive(true);
        credits.SetActive(false);
        dunya1.SetActive(true);
        dunya2.SetActive(false);
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
        dunya1.SetActive(false);
        dunya2.SetActive(true);
    }

    public void back()
    {
        credits.SetActive(false);
        mainCanvas.SetActive(true);
        dunya1.SetActive(true);
        dunya2.SetActive(false);
    }




}
