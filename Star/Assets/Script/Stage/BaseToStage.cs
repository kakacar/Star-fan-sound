using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseToStage : MonoBehaviour
{
    public GameObject nextStage;
    public GameObject player;
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
                SceneManager.UnloadSceneAsync("Base");
                SceneManager.LoadScene("1-2", LoadSceneMode.Additive);
                SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("1-2"));
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
