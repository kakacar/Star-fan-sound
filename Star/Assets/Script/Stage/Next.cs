using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public string[] scenes;
    public Player player;
    public string loadedScene;
    public void NextStage()
    {
        bool load = false;
        load = true;
        if (load)
        {
            player.result.SetActive(false);
            player.F.SetActive(false);
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
