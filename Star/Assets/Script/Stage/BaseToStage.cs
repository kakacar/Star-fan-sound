using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseToStage : MonoBehaviour
{
    public GameObject nextStage;
    public GameObject player;
    public string[] scenes;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nextStage = GameObject.Find("EnterStageText");
        nextStage.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            nextStage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                int i = Random.Range(0, scenes.Length - 1);
                SceneManager.UnloadSceneAsync("Base");
                SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);
                SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenes[i]));
                };
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nextStage.SetActive(false);
        }
    }
}
