using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBot : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public float t;//µL¼Ä®É¶¡
    private Collider col;
    private void Start()
    {
        col = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        t -= Time.deltaTime;
        int currentHp = hp;
        if(currentHp != hp)
        {
            t = 3;
        }
        if(t <= 0)
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }
}
