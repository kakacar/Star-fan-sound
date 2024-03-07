using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseWindow;
    public GameObject settingWindow;
    public GameObject BackpackWindow;

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
        if (settingWindow.activeSelf || pauseWindow.activeSelf || BackpackWindow.activeSelf)
        {
            GetComponent<Canvas>().sortingOrder = 100;
        }
        else if(!settingWindow.activeSelf && !pauseWindow.activeSelf && !BackpackWindow.activeSelf && Time.timeScale == 1)
        {
            GetComponent<Canvas>().sortingOrder = 1;
        }else if (Time.timeScale == 0 && !settingWindow.activeSelf && !pauseWindow.activeSelf && !BackpackWindow.activeSelf)
        {
            GetComponent<Canvas>().sortingOrder = 0;
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
        pauseWindow.SetActive(false);
        GetComponent<Next>().loadedScene = "Base";
        if(SceneManager.GetActiveScene().name != ("Base"))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Base", LoadSceneMode.Additive);
            SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Base"));
            };
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
