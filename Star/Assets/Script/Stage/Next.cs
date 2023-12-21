using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public string[] scenes;
    public bool startRoll;
    public Player player;
    private void Awake()
    {
        startRoll = false;
    }
    private void FixedUpdate()
    {
        if (startRoll)
        {
            int i = Random.Range(0, scenes.Length - 1);
            if (SceneManager.GetActiveScene().name != scenes[i])
            {
                startRoll = false;
                player.result.SetActive(false);
                player.F.SetActive(false);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);
                SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenes[i]));
                };
            }
            else
            {
                i = Random.Range(0, scenes.Length - 1);
            }
        }
    }
    public void NextStage()
    {
        startRoll = true;
    }
}
