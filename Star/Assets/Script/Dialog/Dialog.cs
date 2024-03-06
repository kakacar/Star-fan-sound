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
    public GameObject boxPos;
    public GameObject box;
    public GameObject clear;
    [Header("People")]
    public GameObject p1;
    public GameObject p2;
    [Header("Action Bool")]
    public bool action;
    public bool move;
    public bool jump;
    public bool sword;
    public bool gun;
    public bool kill;
    public bool dialogEnded;
    private void Awake()
    {
        fadeIn.Play("Fade in");
    }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        boxPos.SetActive(false);
        clear.SetActive(false);
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
            clear.SetActive(true);
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
            if(i <= 6 && i >1)
            {
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                action = true;
                Time.timeScale = 1f;
            }
        }
    }
    private void Action()
    {
        if (Input.GetKey(KeyCode.A) && !move || Input.GetKey(KeyCode.D) && !move && i == 2)
        {
            move = true;
            fadeIn.Play("Fade in");
            action = false;
        }
        if(player.jumpCount == 0 && !jump && i ==3)
        {
            jump = true;
            fadeIn.Play("Fade in");
            action = false;
        }
        if(player.CanAss && !sword && i == 4)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                sword = true;
                fadeIn.Play("Fade in");
                action = false;
            }
        }
        if(!player.CanAss && !gun && i == 5)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                gun = true;
                fadeIn.Play("Fade in");
                action = false;
            }
        }
        if(enemy == null && !kill && i == 6)
        {
            kill = true;
            boxPos.SetActive(true);
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
            p1.GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
            p2.GetComponent<RawImage>().color = new Color(125, 125, 125, 255);
        }
    }
}
