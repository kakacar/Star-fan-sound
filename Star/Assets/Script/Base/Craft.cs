using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craft : MonoBehaviour
{
    private Player player;
    public Text[] stuffCount;
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
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
