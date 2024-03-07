using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotUpgrade : MonoBehaviour
{
    public Player player;
    public Canvas canvas;
    public Button[] upGrade;
    public Text info;
    public Text title;
    public int[] currentUpgreadTimes;
    public string currentEffect;
    private void Start()
    {
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }
    public void HpUpgrade()
    {
        upGrade[0].interactable = false;
        upGrade[1].interactable = true;
        upGrade[2].interactable = true;
        if(currentUpgreadTimes[0] == 3)
        {
            title.text = "生命LV + 1(目前LV." + player.robotLevel[0] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "最大HP+1" + "\n" + "機器人無敵時間增加0.5秒";
            if (player.money >= 500 && player.item[4] >= 1)
            {
                upGrade[3].interactable = true;
            }
        }
        else
        {
            title.text = "生命LV + 1(目前LV." + player.robotLevel[0] + ")" + "\n" + "$100";
            info.text = "最大HP+1";
            if (player.money >= 100)
            {
                upGrade[3].interactable = true;
            }
        }
        currentEffect = "HP";
    }
    public void CollectUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = false;
        upGrade[2].interactable = true;
        if (currentUpgreadTimes[2] == 2)
        {
            title.text = "採集LV + 1(目前LV." + player.robotLevel[2] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "採集速度+5%" + "\n" + "採集數量+5";
            if (player.money >= 500 && player.item[4] >= 1)
            {
                upGrade[3].interactable = true;
            }
        }
        else
        {
            title.text = "採集LV + 1(目前LV." + player.robotLevel[2] + ")" + "\n" + "$100";
            info.text = "採集速度+5%";
            if (player.money >= 100)
            {
                upGrade[3].interactable = true;
            }
        }
        currentEffect = "Collect";
    }
    public void SneakUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = false;
        if (currentUpgreadTimes[1] == 1)
        {
            title.text = "潛行LV + 1(目前LV." + player.robotLevel[1] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "採集產生的聲音減少5%" + "\n" + "未完成的效果";
            if (player.money >= 500 && player.item[4] >= 1)
            {
                upGrade[3].interactable = true;
            }
        }
        else
        {
            title.text = "潛行LV + 1(目前LV." + player.robotLevel[1] + ")" + "\n" + "$100";
            info.text = "採集產生的聲音減少5%";
            if (player.money >= 100)
            {
                upGrade[3].interactable = true;
            }
        }
        currentEffect = "Sneak";
    }
    public void UpGrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = true;
        upGrade[3].interactable = false;
        title.text = "";
        info.text = "";
        if(currentEffect == "HP")
        {
            player.robotLevel[0]++;
            if(currentUpgreadTimes[0] == 3)
            {
                currentUpgreadTimes[0] = 1;
                player.GetComponent<PlayerLevel>().robot.t += 0.5f;
                player.money -= 500;
                player.item[4] -= 1;
            }
            else
            {
                currentUpgreadTimes[0]++;
                player.money -= 100;
            }
        }
        if(currentEffect == "Sneak")
        {
            player.robotLevel[1]++;
            player.GetComponent<PlayerLevel>().RobotSoundLess();
            player.money -= 100;
        }
        if(currentEffect == "Collect")
        {
            player.robotLevel[2]++;
            if (currentUpgreadTimes[2] == 2)
            {
                currentUpgreadTimes[2] = 1;
                player.GetComponent<PlayerLevel>().nc.normalCollecting += 5;
                player.GetComponent<PlayerLevel>().rc.rareCollecting += 5;
                player.money -= 500;
                player.item[4] -= 1;
            }
            else
            {
                currentUpgreadTimes[2]++;
                player.money -= 100;
            }
        }
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        canvas.sortingOrder = -1;
    }
}
