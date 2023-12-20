using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUpgrade : MonoBehaviour
{
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
