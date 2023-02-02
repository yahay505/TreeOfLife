using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] public GameObject _pauseMenu;
    [SerializeField] public GameObject _pausebutton;
    public string start;

    public void Menu()
    {
        SceneManager.LoadScene(start);
    }
    public void PauseButton()
    {
        Time.timeScale = 0f; 
        _pauseMenu.SetActive(true);
        _pausebutton.SetActive(false);

    }
    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _pausebutton.SetActive(true);
    }
}