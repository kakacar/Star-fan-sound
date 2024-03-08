using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Dialog dialog;
    public GameObject[] img;
    public GameObject enemy;
    public bool firstCollect;
    private void Start()
    {
        for (int i = 0; i < img.Length; i++)
        {
            img[i].SetActive(false);
        }
        firstCollect = false;
    }
    private void Update()
    {
        if(dialog.i == 1)
        {
            img[0].SetActive(true);
        }
        else if(dialog.i == 2)
        {
            img[0].SetActive(false);
            img[1].SetActive(true);
        }
        else if (dialog.i == 3)
        {
            img[1].SetActive(false);
            img[2].SetActive(true);
        }
        else if(dialog.i == 4)
        {
            img[2].SetActive(false);
            img[3].SetActive(true);
        }
        else if(dialog.i == 5)
        {
            img[3].SetActive(false);
            img[4].SetActive(true);
        }else if(dialog.i == 6)
        {
            img[4].SetActive(false);
        }
        if(!enemy.activeSelf && dialog.i == 6 && dialog.dialogBox.GetComponent<CanvasGroup>().alpha == 0)
        {
            dialog.fadeIn.Play("Fade in");
        }
        if(!enemy.activeSelf && !dialog.dialogEnded && dialog.box.GetComponent<NormalCollect>().collecting)
        {
            firstCollect = true;
            dialog.dialogEnded = true;
            dialog.fadeIn.Play("Fade in");
            dialog.clear.SetActive(true);
        }
    }
}
