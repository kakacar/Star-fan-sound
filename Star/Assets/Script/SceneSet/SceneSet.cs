using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSet : MonoBehaviour
{
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Player&UI")
        {
            SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
            };
        }
    }
}
