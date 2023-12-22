using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
    public GameObject clear;
    public Dialog2 dialog;
    public string[] scenes;
    public string loadedScene;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Player>().firstToBase)
        {
            dialog.enabled = true;
            clear.SetActive(false);
            gameObject.SetActive(true);
        }
        else
        {
            dialog.enabled = false;
            clear.SetActive(true);
            gameObject.SetActive(false);
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
}
