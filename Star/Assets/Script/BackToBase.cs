using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToBase : MonoBehaviour
{
    public GameObject hint;
    private void Start()
    {
        hint.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            hint.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hint.SetActive(false);
        }
    }
}
