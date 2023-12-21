using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{
    [SerializeField] Animator Ani;
    public Transform Enter;
    public Transform Leave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DuctIn()
    {
        Ani.SetTrigger("Enter");
    }
    public void DuctOut()
    {
        Ani.SetTrigger("Leave");
    }
}
