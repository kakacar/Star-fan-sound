using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Player player;
    public GameObject tutorial;
    public bool loaded1;
    public bool loaded2;
    public bool loadedBase;
    void Start()
    {
        if (player.firstToBase && SceneManager.GetActiveScene().name != "1-1")
        {
            tutorial.SetActive(true);
            SceneManager.LoadScene("1-1", LoadSceneMode.Additive);
            SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("1-1"));
            };
        }
    }
}
