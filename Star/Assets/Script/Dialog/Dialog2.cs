using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog2 : MonoBehaviour
{
    public int i;
    public string[] dialog;
    public Text dialogText;
    public Animation fadeIn;
    public GameObject dialogBox;
    private void Awake()
    {
        fadeIn.Play("Fade in");
    }
    private void Update()
    {
        if(dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i <= 1)
        {
            Time.timeScale = 0f;
            FirstDialog();
        }
        else if(dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i >= 2)
        {
            Time.timeScale = 0f;
            SecondDialog();
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
            if (i == 2)
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
        }
    }
}
