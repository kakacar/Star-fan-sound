using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    private Player player;
    public Text moneyText;
    public Button[] sellButton;
    public GameObject[] sell;
    public GameObject[] noDeal;
    private void Awake()
    {
        for (int i = 0; i < sell.Length; i++)
        {
            sell[i].SetActive(true);
        }
        for (int i = 0; i < sell.Length; i++)
        {
            noDeal[i].SetActive(false);
        }
    }
    private void Update()
    {
        moneyText.text = "" + player.money;
        //if (No Item)
        {
            sellButton[0].interactable = false;
        }//else
        {
            sellButton[0].interactable = true;
        }
        //if (No Item)
        {
            sellButton[1].interactable = false;
        }//else
        {
            sellButton[1].interactable = true;
        }
        //if (No Item)
        {
            sellButton[2].interactable = false;
        }//else
        {
            sellButton[2].interactable = true;
        }
        //if (No Item)
        {
            sellButton[3].interactable = false;
        }//else
        {
            sellButton[3].interactable = true;
        }
    }
    public void Sell1()
    {
        player.money += 400;
        sell[0].SetActive(false);
        noDeal[0].SetActive(true);
    }
    public void Sell2()
    {
        player.money += 350;
        sell[1].SetActive(false);
        noDeal[1].SetActive(true);
    }
    public void Sell3()
    {
        player.money += 400;
        sell[2].SetActive(false);
        noDeal[2].SetActive(true);
    }
    public void Sell4()
    {
        player.money += 600;
        sell[3].SetActive(false);
        noDeal[3].SetActive(true);
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
