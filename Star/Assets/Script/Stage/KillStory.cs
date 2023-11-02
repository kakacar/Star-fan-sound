using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillStory : MonoBehaviour
{
    public GameObject plotKillStory;
    public GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<Player>().firstToBase)
        {
            Time.timeScale = 0;
            plotKillStory.SetActive(true);
            if (Input.anyKey)
            {
                plotKillStory.SetActive(false);
                player.GetComponent<Player>().firstToBase = false;
                Time.timeScale = 1;
            }
        }
        else
        {
            plotKillStory.SetActive(false);
            GetComponent<KillStory>().enabled = false;
        }
    }
}
