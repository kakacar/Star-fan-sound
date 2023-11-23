using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Player player;
    public GameObject tutorial;
    void Start()
    {
        if (player.firstToBase && SceneManager.GetActiveScene().name != "1-1")
        {
            tutorial.SetActive(true);
            SceneManager.LoadScene("1-1", LoadSceneMode.Additive);
        }
    }
}
