using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int attackCount = 0;
    public float attackCD = 1.5f;
    public float noCombo = 1.5f;
    [SerializeField] private bool HasDealDamage;
    public Animator ani;
    public Player Player;
    public AniEvent AE;
    [SerializeField]bool HasReset;
    [SerializeField] private Collider AtkCollider;

    // Start is called before the first frame update
    void Start()
    {
        ani = GameObject.Find("Player").GetComponent<Animator>();
        Player = GameObject.Find("Player").GetComponent<Player>();
        AE = GameObject.Find("Player").GetComponent<AniEvent>();

        AtkCollider.enabled = false;
        HasDealDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        //attackCD -= Time.deltaTime;
        noCombo -= Time.deltaTime;

        Atk();
        AtkAni();
        HitBoxSwitch();
    }

    void Atk()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            attackCount ++;
            AE.IsAtk = true;
            HasReset = false;
        }
        
    }

    void AtkAni()
    {
        if (ani.GetCurrentAnimatorStateInfo(1).IsName("Idle"))
        {
            if(attackCount > 0)
            {
                ani.SetInteger("Attack", 1);
                ani.SetBool("IsAtk", true);
                noCombo = 0.25f;
                Player.speed = 1.5f;
                
            }
            else if(noCombo < 0 && !HasReset)
            {
                ani.SetInteger("Attack", 0);
                ani.SetBool("IsAtk", false);
                attackCount = 0;
                Player.speed = 5f;
                HasReset = true;
            }
        }
        else if (ani.GetCurrentAnimatorStateInfo(1).IsName("DS"))
        {
            if (attackCount > 1)
            {
                ani.SetInteger("Attack", 2);
                noCombo = 0.4f;
            }
            else if (noCombo < 0 && !HasReset)
            {
                ani.SetInteger("Attack", 0);
                ani.SetBool("IsAtk", false);
                attackCount = 0;
                Player.speed = 5f;
                HasReset = true;
            }
            
        }
        else if (ani.GetCurrentAnimatorStateInfo(1).IsName("DS 1"))
        {
            if (attackCount > 2)
            {
                ani.SetInteger("Attack", 3);
                noCombo = 0.9f;
            }
            else if (noCombo < 0 && !HasReset)
            {
                ani.SetInteger("Attack", 0);
                ani.SetBool("IsAtk", false);
                attackCount = 0;
                Player.speed = 5f;
                HasReset = true;
            }
            
        }
        else if (ani.GetCurrentAnimatorStateInfo(1).IsName("DS 2"))
        {
            if (attackCount > 3)
            {
                attackCount = 1;
                ani.SetInteger("Attack", 4);
                ani.SetBool("IsAtk", true);
                Player.speed = 1.5f;
            }
            else if (noCombo < 0 && !HasReset)
            {
                ani.SetInteger("Attack", 0);
                ani.SetBool("IsAtk", false);
                attackCount = 0;
                Player.speed = 5f;
                HasReset = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !HasDealDamage)
        {
            HasDealDamage = true;
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
            
        }

    }

    void HitBoxSwitch()
    {
        if (AE.CanDealDamage == true)
        {
            AtkCollider.enabled = true;
        }
        
        if (AE.CanDealDamage == false)
        {
            AtkCollider.enabled = false;
            HasDealDamage = false;
        }
    }
}
