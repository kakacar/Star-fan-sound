using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FieldOfView FOV;
    [SerializeField] private Animator Ani;
    [SerializeField] int Stun;
    [SerializeField] int GetHit;
    [SerializeField] float StunTime;
    [SerializeField] float StunTimer;
    [SerializeField] BeeAttack BeeATK;

    bool StunAni;
    bool PlayDeadAni;

    public float maxHp;
    public float hp;
    public GameObject hpSlider;
    public GameObject hpPrefab;
    public bool enemyDead = false;
    private void Start()
    {
        maxHp = hp;
    }

    void Update()
    {
        if (hp <= 0)
        {

            enemyDead = true;
            Ani.SetBool("DeadCheck", true);
            if (!PlayDeadAni && !FOV.BeStab)
            {
                PlayDeadAni = true;
                Ani.SetTrigger("Dead");
            }
        }
        StunTimeCount();
        HpSlider();
    }

    void StunTimeCount()
    {
        if (GetHit == Stun)
        {
            Ani.SetTrigger("BeingHit");
            BeeATK.BeamAtkEnd();
            GetHit = 0;
            FOV.ActState = FieldOfView.ActionState.Stun;
        }

        if (GetHit != 0)
        {
            StunTimer += Time.deltaTime;
            if (StunTimer > StunTime)
            {
                GetHit = 0;
                StunTimer = 0;
            }
        }
    }
    private void HpSlider()
    {
        if (hpSlider == null)
        {
            hpSlider = Instantiate(hpPrefab, transform.position, Quaternion.identity);
            hpSlider.transform.SetParent(GameObject.Find("EnemyHpBar").transform);
        }
        else
        {
            Vector3 worldToScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
            hpSlider.transform.position = worldToScreenPoint + new Vector3(0f, 30f, 0f);
        }
    }
    public void TakeDamage(float Damage)
    {
        hp = hp - Damage;
        hpSlider.GetComponent<Slider>().maxValue = maxHp;
        hpSlider.GetComponent<Slider>().value = hp;
        FOV.canSeePlayer = true;
        GetHit++;
    }

    public void ReFromStun()
    {
        FOV.ActState = FieldOfView.ActionState.Standy;
    }

    public void Dead()
    {
        Destroy(hpSlider.gameObject);
        Destroy(this.gameObject);
    }
}