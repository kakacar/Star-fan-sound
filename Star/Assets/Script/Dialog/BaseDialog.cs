using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseDialog : MonoBehaviour
{
    public int i;
    public string[] dialog;
    public Text dialogText;
    public Animation fadeIn;
    public Texture cg2;
    public GameObject dialogBox;
    public Animation black;
    public GameObject people;
    public GameObject peopleName;
    public Player player;
    public GameObject p1;
    public GameObject p2;
    public GameObject p1n;
    public GameObject p2n;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player.firstToBase)
        {
            Time.timeScale = 0;
            GetComponent<Canvas>().sortingOrder = 1;
        }
        else
        {
            GetComponent<Canvas>().sortingOrder = -1;
        }
    }
    private void Update()
    {
        if (player.firstToBase)
        {
            if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i <= 1)
            {
                Time.timeScale = 0f;
                GetComponent<Canvas>().sortingOrder = 1;
                FirstDialog();
            }
            else if (black.transform.GetComponent<CanvasGroup>().alpha == 0 && i == 2)
            {
                Time.timeScale = 0f;
                GetComponent<Canvas>().sortingOrder = 1;
                SecondDialog();
            }
            else if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i >= 3 && i < 7)
            {
                Time.timeScale = 0f;
                GetComponent<Canvas>().sortingOrder = 1;
                ThirdDialog();
            }
            else if (dialogBox.GetComponent<CanvasGroup>().alpha == 1 && i == 7)
            {
                Time.timeScale = 0f;
                GetComponent<Canvas>().sortingOrder = 1;
                FourthDialog();
            }
            if (dialogBox.GetComponent<CanvasGroup>().alpha == 0 && i == 3)
            {
                fadeIn.Play("Fade in");
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
                black.transform.GetComponent<CanvasGroup>().alpha = 1;
                dialogBox.GetComponent<RawImage>().texture = cg2;
                dialogBox.GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                Time.timeScale = 1f;
                black.Play("Fade out");
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
                dialogBox.GetComponent<RawImage>().texture = null;
                dialogBox.GetComponent<RawImage>().color = new Color(0, 0, 0, 0.51f);
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                p1.SetActive(true);
                p2.SetActive(false);
                p1n.SetActive(true);
                p2n.SetActive(false);
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
            if (i == 7)
            {
                dialogBox.GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<Canvas>().sortingOrder = -1;
                Time.timeScale = 1f;
            }
        }
    }
    private void FourthDialog()
    {
        dialogText.text = dialog[i];
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            i++;
            player.firstToBase = false;
            GetComponent<Canvas>().sortingOrder = -1;
            Time.timeScale = 1f;
        }
    }
}
