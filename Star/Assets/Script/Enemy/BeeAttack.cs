using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    [SerializeField] private LineRenderer Beam;
    [SerializeField] private ParticleSystem[] Impact;

    [SerializeField]private float atkCD;
    [SerializeField] private float ChargeTime;

    private bool UseBeam;
    

    private float LAtkTimer;

    public FieldOfView FOV;

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
        Beam.enabled = false;
        UseBeam = false;
    }

    void Update()
    {
        Action();
    }

    void Action()
    {
        if(FOV.ActState == FieldOfView.ActionState.Patrol)
        {
            animator.SetBool("Moving", true);
        }
        else if(FOV.ActState == FieldOfView.ActionState.Standy)
        {
            animator.SetBool("Moving", false);
        }

        if (FOV.ActState == FieldOfView.ActionState.CloseCombat)
        {
            animator.SetBool("Moving", false);
            Attack();
        }

        if (FOV.ActState == FieldOfView.ActionState.LongRangeAttack)
        {
            animator.SetBool("Moving", false);

            if (LRAtk == LRAtkState.Start)
            {
                animator.SetTrigger("StartCh");
                LRAtk = LRAtkState.Charging;
                
            }
            else if (LRAtk == LRAtkState.Charging)
            {
                animator.SetBool("Charging",true);
                LAtkTimer -= Time.deltaTime;
                if (LAtkTimer < 0)
                {
                    LRAtk = LRAtkState.Fire;
                    LAtkTimer = ChargeTime;
                }
                
            }
            else if (LRAtk == LRAtkState.Fire)
            {
                
                animator.SetTrigger("Fire");

                if (Beam.enabled)
                {
                    Shoot();
                }

            }
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

    void Shoot()
    {
        Beam.SetPosition(0, firePoint.position);

        Vector3 Rayorigin = firePoint.position;
        RaycastHit Hit;
        if (Physics.Raycast(Rayorigin, firePoint.forward, out Hit))
        {
            
            Beam.SetPosition(1, Hit.point);

            Vector3 ImpactDir = firePoint.position - Hit.point;
            Impact[0].transform.position = Hit.point - ImpactDir.normalized/6f;
            Impact[0].transform.rotation = Quaternion.LookRotation(ImpactDir);
            if(Hit.transform.gameObject.tag == "Player")
            {
                Hit.transform.gameObject.GetComponent<Player>().BeingHit(10);
                
            }
            //Debug.Log(ImpactDir);
        }
        else
        {
            Beam.SetPosition(1, firePoint.position + (firePoint.transform.forward*7));
            //Debug.Log("2nd");
        }
    }

    public void ChargeParticle()
    {
        Impact[2].Play();
    }

    public void BeamAtk()
    {
        UseBeam = true;
        if(Beam.enabled == false)
        {
            Beam.enabled = true;
            Impact[0].Play();
            Impact[1].Play();
        }
        
    }

    public void BeamAtkEnd()
    {
        UseBeam = false;
        if (Beam.enabled == true)
        {
            Beam.enabled = false;
            Impact[0].Stop();
            Impact[1].Stop();
            Impact[2].Stop();
        }
        
    }

    public void ResetState()
    {
        animator.SetBool("Charging", false);
        FOV.ActState = FieldOfView.ActionState.Standy;
        FOV.HasRoll = false;
        LRAtk = LRAtkState.Start;
    }
}
