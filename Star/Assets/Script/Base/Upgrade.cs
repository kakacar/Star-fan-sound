using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour
{
    private Player player;
    public Canvas canvas;
    public void HpUpgrade()
    {

    }
    public void CollectUpgrade()
    {
        Debug.Log("Collect Upgrade");
    }
    public void SneakUpgrade()
    {
        Debug.Log("Doged Upgrade");
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        canvas.sortingOrder = -1;
    }
}
