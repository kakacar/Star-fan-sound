using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
    public GameObject clearText;
    public Dialog2 dialog;
    public string[] scenes;
    public string loadedScene;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Player>().firstToBase)
        {
            dialog.enabled = true;
        }
        else
        {
            dialog.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (player.GetComponent<Player>().firstToBase)
            {
                dialog.fadeIn.Play("Fade in");
            }
        }
        if(other.tag == "Cow")
        {
            if (player.GetComponent<Player>().firstToBase)
            {
                dialog.fadeIn.Play("Fade in");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!player.GetComponent<Player>().firstToBase)
            {
                clearText.SetActive(true);
                bool load = false;
                load = true;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (load)
                    {
                        clearText.SetActive(false);
                        int i = Random.Range(0, scenes.Length - 1);
                        loadedScene = scenes[i];
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
        if (other.tag == ("Player"))
        {
            clearText.SetActive(false);
        }
    }
}
