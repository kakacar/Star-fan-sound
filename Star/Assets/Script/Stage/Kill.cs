using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject player;
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
                other.GetComponent<Player>().hp -= 100;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("Base");
                }
            }
        }
    }
}
