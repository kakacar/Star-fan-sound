using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] Sound Sound;
    [SerializeField] Animation[] anim;
    [SerializeField] GameObject normalLight;
    [SerializeField] GameObject redLight;
    public bool warning;
    void Update()
    {
        if (Sound == null)
        {
            GameObject Player = GameObject.Find("Player");
            Sound = Player.GetComponent<Sound>();
        }

        TurnOnAlarm();
    }

    void TurnOnAlarm()
    {
        if (Sound.enemyWarning != 100 || !warning)
        {
            if (Sound.Soundloss <= 0)
            {
                Sound.enemyWarning -= 5f;
                Sound.currentSound -= 10f;

                Sound.Soundloss = 3f;
            }
            else
            {
                Sound.Soundloss -= Time.deltaTime;
            }
            normalLight.SetActive(true);
            redLight.SetActive(false);
        }
        else if(Sound.enemyWarning == 100 || warning)
        {
            normalLight.SetActive(false);
            redLight.SetActive(true);
            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].Play("Flash");
            }
        }
        if (Sound.currentSound == 100)
        {
            Sound.enemyWarning += Time.deltaTime;
        }
    }
}
