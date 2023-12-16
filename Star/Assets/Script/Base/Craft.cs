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
        stuffCount[0].text = "電路板" + "<br>" + "：" + player.stuff[0];
        stuffCount[1].text = "貴金屬" + "<br>" + "：" + player.stuff[1];
        stuffCount[2].text = "能源金屬" + "<br>" + "：" + player.stuff[2];
        stuffCount[3].text = "合成液" + "<br>" + "：" + player.stuff[3];
        stuffCount[4].text = "生物組織" + "<br>" + "：" + player.stuff[4];
        stuffCount[5].text = "生物DNA" + "<br>" + "：" + player.stuff[5];
        stuffCount[6].text = "複合金屬" + "<br>" + "：" + player.stuff[6];
        stuffCount[7].text = "能量精華" + "<br>" + "：" + player.stuff[7];
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
