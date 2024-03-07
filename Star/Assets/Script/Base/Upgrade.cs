using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour
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
        if (player == null)
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
        if (currentUpgreadTimes[0] == 5)
        {
            title.text = "生命LV + 1(目前LV."+ player.playerLevel[0]+")" + "\n" + "$500 + 生命精華*1";
            info.text = "最大HP+10" + "\n" + "彈匣容量+1";
        }
        else
        {
            title.text = "生命LV + 1(目前LV." + player.playerLevel[0] + ")" + "\n" + "$100";
            info.text = "最大HP+10";
        }
        currentEffect = "HP";
    }
    public void CollectUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = false;
        upGrade[2].interactable = true;
        upGrade[3].interactable = true;
        if (currentUpgreadTimes[2] == 5)
        {
            title.text = "採集LV + 1(目前LV." + player.playerLevel[2] + ")" + "\n" + "$500 + 生命精華*1";
            info.text = "死亡後留下的資源+5%" + "\n" + "復活次數+1";
        }
        else
        {
            title.text = "採集LV + 1(目前LV." + player.playerLevel[2] + ")" + "\n" + "$100";
            info.text = "死亡後留下的資源+5%";
        }
        currentEffect = "Collect";
    }
    public void SneakUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = false;
        upGrade[3].interactable = true;
        if (currentUpgreadTimes[1] == 4)
        {
            title.text = "潛行LV + 1(目前LV." + player.playerLevel[1] + ")" + "\n" + "$500 + 生命精華*1";
            info.text = "開槍聲響-3" + "\n" + "技能冷卻-2s" + "\n" + "技能持續時間+2s";
        }
        else if (currentUpgreadTimes[1] < 4)
        {
            title.text = "潛行LV + 1(目前LV." + player.playerLevel[1] + ")" + "\n" + "$100";
            info.text = "開槍聲響-3" + "\n" + "技能冷卻-2s";
        }else if (player.playerLevel[1] >= 5)
        {
            title.text = "潛行LV." + player.playerLevel[1];
            info.text = "已升至最高等級";
            upGrade[3].interactable = false;
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
        if (currentEffect == "HP")
        {
            player.playerLevel[0]++;
            if (currentUpgreadTimes[0] == 5)
            {
                currentUpgreadTimes[0] = 1;
                player.GetComponent<PlayerLevel>().bullet.maxBullet += 1;
            }
            else
            {
                currentUpgreadTimes[0]++;
            }
        }
        if (currentEffect == "Sneak")
        {
            player.playerLevel[1]++;
            if (currentUpgreadTimes[1] == 4)
            {
                player.GetComponent<DisableSoundSkill>().skillDuration += 2;
            }
            else
            {
                currentUpgreadTimes[1]++;
            }
        }
        if (currentEffect == "Collect")
        {
            player.playerLevel[2]++;
            if (currentUpgreadTimes[2] == 5)
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
