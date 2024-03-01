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
            title.text = "�ͩRLV + 1(�ثeLV." + player.robotLevel[0] + ")" + "\n" + "$500 + �q�ϸ˸m*1";
            info.text = "�̤jHP+1" + "\n" + "�����H�i�_���@��";
        }
        else
        {
            title.text = "�ͩRLV + 1(�ثeLV." + player.robotLevel[0] + ")" + "\n" + "$100";
            info.text = "�̤jHP+1";
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
            title.text = "�Ķ�LV + 1(�ثeLV." + player.robotLevel[2] + ")" + "\n" + "$500 + �q�ϸ˸m*1";
            info.text = "�Ķ��t��+5%" + "\n" + "�Ķ��ƶq+5";
        }
        else
        {
            title.text = "�Ķ�LV + 1(�ثeLV." + player.robotLevel[2] + ")" + "\n" + "$100";
            info.text = "�Ķ��t��+5%";
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
            title.text = "���LV + 1(�ثeLV." + player.robotLevel[1] + ")" + "\n" + "$500 + �q�ϸ˸m*1";
            info.text = "�����n�������j+1s" + "\n" + "�Ķ����ͪ��n�����5%";
        }
        else
        {
            title.text = "���LV + 1(�ثeLV." + player.robotLevel[1] + ")" + "\n" + "$100";
            info.text = "�����n�������j+1s";
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
