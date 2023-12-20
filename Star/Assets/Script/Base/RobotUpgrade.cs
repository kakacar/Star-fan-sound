using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUpgrade : MonoBehaviour
{
    public GameObject upgradeText;
    public GameObject upgradeWindow;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            upgradeText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && !upgradeWindow.activeSelf)
            {
                upgradeWindow.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Escape) && upgradeWindow.activeSelf)
            {
                upgradeWindow.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            upgradeText.SetActive(false);
        }
    }
}
