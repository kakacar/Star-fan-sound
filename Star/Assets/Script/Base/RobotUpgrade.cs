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
    private void FixedUpdate()
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
        upGrade[3].interactable = true;
        if(currentUpgreadTimes[0] == 3)
        {
            title.text = "生命LV + 1(目前LV." + player.robotLevel[0] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "最大HP+1" + "\n" + "機器人可復活一次";
        }
        else
        {
            title.text = "生命LV + 1(目前LV." + player.robotLevel[0] + ")" + "\n" + "$100";
            info.text = "最大HP+1";
        }
        currentEffect = "HP";
    }
    public void CollectUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = false;
        upGrade[2].interactable = true;
        upGrade[3].interactable = true;
        if (currentUpgreadTimes[2] == 2)
        {
            title.text = "採集LV + 1(目前LV." + player.robotLevel[2] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "採集速度+5%" + "\n" + "採集數量+5";
        }
        else
        {
            title.text = "採集LV + 1(目前LV." + player.robotLevel[2] + ")" + "\n" + "$100";
            info.text = "採集速度+5%";
        }
        currentEffect = "Collect";
    }
    public void SneakUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = false;
        upGrade[3].interactable = true;
        if (currentUpgreadTimes[1] == 1)
        {
            title.text = "潛行LV + 1(目前LV." + player.robotLevel[1] + ")" + "\n" + "$500 + 電磁裝置*1";
            info.text = "產生聲音的間隔+1s" + "\n" + "採集產生的聲音減少5%";
        }
        else
        {
            title.text = "潛行LV + 1(目前LV." + player.robotLevel[1] + ")" + "\n" + "$100";
            info.text = "產生聲音的間隔+1s";
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
                currentUpgreadTimes[0] = 0;
            }
            else
            {
                currentUpgreadTimes[0]++;
            }
        }
        if(currentEffect == "Sneak")
        {
            player.robotLevel[1]++;
            if (currentUpgreadTimes[1] == 1)
            {
                currentUpgreadTimes[1] = 0;
            }
            else
            {
                currentUpgreadTimes[1]++;
            }
        }
        if(currentEffect == "Collect")
        {
            player.robotLevel[2]++;
            if (currentUpgreadTimes[2] == 2)
            {
                currentUpgreadTimes[2] = 0;
            }
            else
            {
                currentUpgreadTimes[2]++;
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
