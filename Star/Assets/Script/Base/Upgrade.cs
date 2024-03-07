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
            title.text = "�ͩRLV + 1(�ثeLV."+ player.playerLevel[0]+")" + "\n" + "$500 + �ͩR���*1";
            info.text = "�̤jHP+10" + "\n" + "�u�X�e�q+1";
        }
        else
        {
            title.text = "�ͩRLV + 1(�ثeLV." + player.playerLevel[0] + ")" + "\n" + "$100";
            info.text = "�̤jHP+10";
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
            title.text = "�Ķ�LV + 1(�ثeLV." + player.playerLevel[2] + ")" + "\n" + "$500 + �ͩR���*1";
            info.text = "���`��d�U���귽+5%" + "\n" + "�_������+1";
        }
        else
        {
            title.text = "�Ķ�LV + 1(�ثeLV." + player.playerLevel[2] + ")" + "\n" + "$100";
            info.text = "���`��d�U���귽+5%";
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
            title.text = "���LV + 1(�ثeLV." + player.playerLevel[1] + ")" + "\n" + "$500 + �ͩR���*1";
            info.text = "�}�j�n�T-3" + "\n" + "�ޯ�N�o-2s" + "\n" + "�ޯ����ɶ�+2s";
        }
        else if (currentUpgreadTimes[1] < 4)
        {
            title.text = "���LV + 1(�ثeLV." + player.playerLevel[1] + ")" + "\n" + "$100";
            info.text = "�}�j�n�T-3" + "\n" + "�ޯ�N�o-2s";
        }else if (player.playerLevel[1] >= 5)
        {
            title.text = "���LV." + player.playerLevel[1];
            info.text = "�w�ɦ̰ܳ�����";
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
