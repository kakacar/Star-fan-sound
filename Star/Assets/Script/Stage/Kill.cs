using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
    public GameObject clearText;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (player.GetComponent<Player>().firstToBase)
            {
                //other.GetComponent<Player>().hp -= 100;
                other.GetComponent<Player>().hp = 0;
            }
            else
            {
                clearText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("Base");
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
