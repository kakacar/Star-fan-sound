using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tutorials;
    public int i = 1;

    void Awake()
    {
        player = GameObject.Find("Player");
        player.GetComponent<Sound>().enabled = false;
        player.GetComponent<BulletCount>().enabled = false;
        Time.timeScale = 0;
        tutorials[0].SetActive(true);
        tutorials[1].SetActive(false);
        tutorials[2].SetActive(false);
        tutorials[3].SetActive(false);
        tutorials[4].SetActive(false);
        tutorials[5].SetActive(false);
        tutorials[6].SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (i >= tutorials.Length)
            {
                player.GetComponent<Sound>().enabled = true;
                player.GetComponent<BulletCount>().enabled = true;
                Time.timeScale = 1;
                gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
            else
            {
                tutorials[i].SetActive(true);
                tutorials[i - 1].SetActive(false);
            }
            i++;
        }
    }
}
