using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    private Player player;
    public Text[] stuffCount;
    public Button[] craftButton;
    private void Update()
    {
        stuffCount[0].text = "�q���O" + "<br>" + "�G" + player.stuff[0];
        stuffCount[1].text = "�Q����" + "<br>" + "�G" + player.stuff[1];
        stuffCount[2].text = "�෽����" + "<br>" + "�G" + player.stuff[2];
        stuffCount[3].text = "�X���G" + "<br>" + "�G" + player.stuff[3];
        stuffCount[4].text = "�ͪ���´" + "<br>" + "�G" + player.stuff[4];
        stuffCount[5].text = "�ͪ�DNA" + "<br>" + "�G" + player.stuff[5];
        stuffCount[6].text = "�ƦX����" + "<br>" + "�G" + player.stuff[6];
        stuffCount[7].text = "��q���" + "<br>" + "�G" + player.stuff[7];
        CanCraftOrNot();
    }
    private void CanCraftOrNot()
    {
        if (player.stuff[0]! <= 0 || player.stuff[1]! <= 0 || player.stuff[4]! <= 0)
        {
            craftButton[0].interactable = true;
        }
        else
        {
            craftButton[0].interactable = false;
        }

        if (player.stuff[5]! <= 0 || player.stuff[6]! <= 0 || player.stuff[7]! <= 0)
        {
            craftButton[1].interactable = true;
        }
        else
        {
            craftButton[1].interactable = false;
        }

        if (player.stuff[0]! <= 0 || player.stuff[1]! <= 0 || player.stuff[2]! <= 0)
        {
            craftButton[2].interactable = true;
        }
        else
        {
            craftButton[2].interactable = false;
        }

        if (player.stuff[3]! <= 0 || player.stuff[4]! <= 0 || player.stuff[5]! <= 0 || player.stuff[7]! <= 0)
        {
            craftButton[3].interactable = true;
        }
        else
        {
            craftButton[3].interactable = false;
        }
    }
    public void Craft1()
    {
        player.stuff[0] -= 1;
        player.stuff[1] -= 1;
        player.stuff[4] -= 1;
        player.item[0] += 1;
    }
    public void Craft2()
    {
        player.stuff[5] -= 1;
        player.stuff[6] -= 1;
        player.stuff[7] -= 1;
        player.item[1] += 1;
    }
    public void Craft3()
    {
        player.stuff[0] -= 1;
        player.stuff[1] -= 1;
        player.stuff[2] -= 1;
        player.item[2] += 1;
    }
    public void Craft4()
    {
        player.stuff[3] -= 1;
        player.stuff[4] -= 1;
        player.stuff[5] -= 1;
        player.stuff[7] -= 1;
        player.item[3] += 1;
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
