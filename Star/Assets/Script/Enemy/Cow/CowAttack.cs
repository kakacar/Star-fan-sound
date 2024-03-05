using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAttack : MonoBehaviour
{
    public Animator animator;
    
    [SerializeField] private ParticleSystem[] Impact;

    [SerializeField]private float atkCD;
    [SerializeField] private float ChargeTime;

    

    private float LAtkTimer;

    public FOVC FOV;

    private LRAtkState LRAtk;

    private enum LRAtkState
    {
        Start,
        Charging,
        Fire,
    } 

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        LAtkTimer = ChargeTime;
        
    }

    void Update()
    {
        Action();
    }

    void Action()
    {
        if(FOV.ActState == FOVC.ActionState.Patrol)
        {
            animator.SetBool("Moving", true);
        }
        else if(FOV.ActState == FOVC.ActionState.Standy)
        {
            animator.SetBool("Moving", false);
        }

        if (FOV.ActState == FOVC.ActionState.CloseCombat)
        {
            animator.SetBool("Moving", false);
            Attack();
        }

        if (FOV.ActState == FOVC.ActionState.LongRangeAttack)
        {
            animator.SetBool("Moving", false);

            
        }

    }

    void Attack()
    {
        if (atkCD < 0)
        {
            animator.SetTrigger("CAtk");
            atkCD = 1.7f;
        }
        atkCD -= Time.deltaTime;
    }

    

    public void ResetState()
    {
        animator.SetBool("Charging", false);
        FOV.ActState = FOVC.ActionState.Standy;
        FOV.HasRoll = false;
        LRAtk = LRAtkState.Start;
    }
}
