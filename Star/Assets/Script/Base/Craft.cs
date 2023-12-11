using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    private Player player;
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
