using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}
