using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public Animation[] anim;
    public GameObject text;
    public int i;
    bool test;

    void Awake()
    {
        anim[0].Play("Fade in");
        text.SetActive(true);
    }
    void Update()
    {
        if(i <= 5)
        {
            test = true;
        }
        else
        {
            test = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && test)
        {
            i++;
            anim[i].Play("Fade in");
        }
        if(!test)
        {
            SceneManager.LoadScene("Player&UI");
        }
    }
}
