using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Player player;
    void Start()
    {
        if (player.firstToBase && SceneManager.sceneCount<=1)
        {
            SceneManager.LoadScene("1-1", LoadSceneMode.Additive);
        }
    }
}
