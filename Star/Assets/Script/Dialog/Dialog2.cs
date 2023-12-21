using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog2 : MonoBehaviour
{
    public int i;
    public string[] dialog;
    public Text dialogText;
    public Animation fadeIn;
    public GameObject dialogBox;
    public Texture cg1;
    public GameObject cow;
    public Alarm alarm;
    public Animation black;
    public Player player;
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
        if (player.firstToBase)
        {
            if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i <= 1)
            {
                Time.timeScale = 0f;
                FirstDialog();
            }
            else if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i == 2)
            {
                Time.timeScale = 0f;
                SecondDialog();
            }
            else if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i >= 3 && i <= dialog.Length - 1 && cow.transform.position.y <= 9.5f)
            {
                Time.timeScale = 0f;
                ThirdDialog();
            }
            else if (i >= dialog.Length)
            {
                Time.timeScale = 1f;
                black.Play("Fade in");
                if (black.transform.GetComponent<CanvasGroup>().alpha == 1)
                {
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                    SceneManager.LoadScene("Base", LoadSceneMode.Additive);
                }
            }
        }
        else
        {
            black.GetComponent<CanvasGroup>().alpha = 0;
            dialogBox.GetComponent<CanvasGroup>().alpha = 0;
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
            if (i == 3)
            {
                alarm.warning = true;
                cow.SetActive(true);
                dialogBox.GetComponent<RawImage>().texture = cg1;
                dialogBox.GetComponent<RawImage>().color = new Color(255,255,255,255);
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                Time.timeScale = 1f;
            }
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
