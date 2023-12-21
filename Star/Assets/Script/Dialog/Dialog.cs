using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public int i;
    public string[] dialog;
    public Text dialogText;
    public Animation fadeIn;
    public GameObject dialogBox;
    public Tutorial tutorial;
    private void Awake()
    {
        fadeIn.Play("Fade in");
    }
    private void Update()
    {
        if(dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i <= 5)
        {
            Time.timeScale = 0f;
            FirstDialog();
        }
        else if(dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i == 6)
        {
            Time.timeScale = 0f;
            SecondDialog();
        }
        else if(dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i >= 7 && i < 9 && tutorial.firstCollect == true)
        {
            Time.timeScale = 0f;
            ThirdDialog();
        }
        else if(i >= dialog.Length)
        {
            dialogBox.GetComponent<CanvasGroup>().alpha = 0;
            Time.timeScale = 1f;
        }
    }
    private void FirstDialog()
    {
        dialogText.text = dialog[i];
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            if (i == 6)
            {
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                Time.timeScale = 1f;
            }
        }
    }
    private void SecondDialog()
    {
        dialogText.text = dialog[i];
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            dialogBox.GetComponent<CanvasGroup>().alpha = 0;
            Time.timeScale = 1f;
        }
    }
    private void ThirdDialog()
    {
        dialogText.text = dialog[i];
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
        }
    }
}
