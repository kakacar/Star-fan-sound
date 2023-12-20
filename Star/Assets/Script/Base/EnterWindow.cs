using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class EnterWindow : MonoBehaviour
{
    public GameObject Text;
    public GameObject Window;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.F) && !Window.activeSelf)
            {
                Window.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Text.SetActive(false);
        }
    }
}
