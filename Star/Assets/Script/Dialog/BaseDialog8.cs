using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialog8 : MonoBehaviour
{
    public Player player;
    public BaseDialog dialog;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && player.firstToBase == true)
        {
            dialog.fadeIn.Play("Fade in");
        }
    }
}
