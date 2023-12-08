using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseWindow;
    public GameObject settingWindow;

    [Header("Be Choose")]
    [SerializeField] private GameObject resumeBeChoose;
    [SerializeField] private GameObject settingBeChoose;
    [SerializeField] private GameObject quitBeChoose;
    [SerializeField] private GameObject returnBeChoose;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseWindow.activeSelf && !settingWindow.activeSelf && Time.timeScale != 0)
        {
            pauseWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OnResumeClick()
    {
        pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnSettingClick()
    {
        pauseWindow.SetActive(false);
        settingBeChoose.SetActive(false);
        settingWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnQuitClick()
    {
        if(SceneManager.GetActiveScene().name != ("Base"))
        {
            SceneManager.LoadScene("Base");
        }
        else
        {
            Destroy(GameObject.Find("Player"));
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void OnReturnClick()
    {
        settingWindow.SetActive(false);
        returnBeChoose.SetActive(false);
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnResumePointEnter()
    {
        resumeBeChoose.SetActive(true);
    }
    public void OnSettingPointEnter()
    {
        settingBeChoose.SetActive(true);
    }
    public void OnQuitPointEnter()
    {
        quitBeChoose.SetActive(true);
    }
    public void OnReturnPointEnter()
    {
        returnBeChoose.SetActive(true);
    }
    public void OnResumePointExit()
    {
        resumeBeChoose.SetActive(false);
    }
    public void OnSettingPointExit()
    {
        settingBeChoose.SetActive(false);
    }
    public void OnQuitPointExit()
    {
        quitBeChoose.SetActive(false);
    }
    public void OnReturnPointExit()
    {
        returnBeChoose.SetActive(false);
    }
}
