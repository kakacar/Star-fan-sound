using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour
{
    public Canvas canvas;
    public Button[] upGrade;
    public Text info;
    public void HpUpgrade()
    {
        upGrade[0].interactable = false;
        upGrade[1].interactable = true;
        upGrade[2].interactable = true;
        upGrade[3].interactable = true;
        info.text = "1";
    }
    public void CollectUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = false;
        upGrade[2].interactable = true;
        upGrade[3].interactable = true;
        info.text = "2";
    }
    public void SneakUpgrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = false;
        upGrade[3].interactable = true;
        info.text = "3";
    }
    public void UpGrade()
    {
        upGrade[0].interactable = true;
        upGrade[1].interactable = true;
        upGrade[2].interactable = true;
        upGrade[3].interactable = false;
        info.text = "";
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        canvas.sortingOrder = -1;
    }
}
