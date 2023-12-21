using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
    public GameObject clearText;
    public Dialog2 dialog;
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
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.UnloadSceneAsync("1-2");
                    SceneManager.LoadScene("Base", LoadSceneMode.Additive);
                    SceneManager.sceneLoaded += (Scene sc, LoadSceneMode loadSceneMode) =>
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Base"));
                    };
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
