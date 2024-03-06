using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterWindow : MonoBehaviour
{
    public GameObject Text;
    public GameObject Window;
    public Canvas canvas;
    float t;
    private void Update()
    {
        t = Time.deltaTime;
        if(t <= 0)
        {
            Text.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            t = 0.5f;
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.F) && !Window.activeSelf)
            {
                canvas.sortingOrder = 10;
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
