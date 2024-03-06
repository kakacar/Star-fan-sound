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
    public Player player;
    public GameObject enemy;
    [Header("Action Bool")]
    public bool action;
    public bool move;
    public bool jump;
    public bool sword;
    public bool gun;
    public bool kill;
    private void Awake()
    {
        fadeIn.Play("Fade in");
    }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
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
        if (action)
        {
            Action();
        }
    }
    private void FirstDialog()
    {
        dialogText.text = dialog[i];
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            if(i <= 5 && i >1)
            {
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                action = true;
                Time.timeScale = 1f;
            }
            if (i == 6)
            {
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                Time.timeScale = 1f;
            }
        }
    }
    private void Action()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) && !move)
        {
            move = true;
            fadeIn.Play("Fade in");
            action = false;
        }
        if(player.jumpCount == 0 && !jump)
        {
            jump = true;
            fadeIn.Play("Fade in");
            action = false;
        }
        if(Input.GetKey(KeyCode.Alpha2) && !sword)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                sword = true;
                fadeIn.Play("Fade in");
                action = false;
            }
        }
        if(Input.GetKey(KeyCode.Alpha1) && !gun)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                gun = true;
                fadeIn.Play("Fade in");
                action = false;
            }
        }
        if(enemy == null && !kill)
        {
            kill = true;
            fadeIn.Play("Fade in");
            action = false;
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
