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
    public string loadedScene;
    private void Awake()
    {
        nextStage = GameObject.Find("EnterStageText");
        nextStage.SetActive(false);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().hp = 100;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            nextStage.SetActive(true);
            if (Input.GetKeyUp(KeyCode.F))
            {
                bool load = false;
                load = true;
                player.GetComponent<Player>().firstToBase = false;
                if (load) 
                {
                    int i = Random.Range(0, scenes.Length);
                    loadedScene = scenes[i];
                    if (loadedScene != SceneManager.GetActiveScene().name)
                    {
                        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                        SceneManager.LoadScene(loadedScene, LoadSceneMode.Additive);
                        SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
                        {
                            SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadedScene));
                        };
                        load = false;
                    }
                }
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
