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
        stuffCount[0].text = "電路板" + "<br>" + "：" + player.stuff[0];
        stuffCount[1].text = "貴金屬" + "<br>" + "：" + player.stuff[1];
        stuffCount[2].text = "能源金屬" + "<br>" + "：" + player.stuff[2];
        stuffCount[3].text = "合成液" + "<br>" + "：" + player.stuff[3];
        stuffCount[4].text = "生物組織" + "<br>" + "：" + player.stuff[4];
        stuffCount[5].text = "生物DNA" + "<br>" + "：" + player.stuff[5];
        stuffCount[6].text = "複合金屬" + "<br>" + "：" + player.stuff[6];
        stuffCount[7].text = "能量精華" + "<br>" + "：" + player.stuff[7];
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
