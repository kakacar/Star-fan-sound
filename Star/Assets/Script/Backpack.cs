using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public GameObject backpack;
    private void Start()
    {
        backpack.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backpack.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    public void OpenBackpack()
    {
        backpack.SetActive(true);
        Time.timeScale = 0;
    }
}
