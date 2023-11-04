using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Sound sound;
    private DisableSoundSkill skill;
    //[SerializeField] GameObject GunSpot;
    [SerializeField] GameObject bulletPrefab; // �l�u���w�s��
    [SerializeField] Transform firePoint; // �l�u�o�g���_�I
    [SerializeField] Animator ani;
    [SerializeField] BulletCount BC;

    [SerializeField] float bulletForce = 20f;
    [SerializeField] float noCombo;

    private bool CanShoot;

    void Start()
    {
        sound = GameObject.Find("Player").GetComponent<Sound>();
        ani = GameObject.Find("Player").GetComponent<Animator>();
        BC = GameObject.Find("Player").GetComponent<BulletCount>();
        skill = GameObject.Find("Player").GetComponent<DisableSoundSkill>();
    }

    void Update()
    {
        noCombo -= Time.deltaTime;

        Fire();
    }

    //Gun
    void Fire()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).IsName("PistolIdle1") || ani.GetCurrentAnimatorStateInfo(0).IsName("AimRun") || ani.GetCurrentAnimatorStateInfo(0).IsName("AimFall"))
        {
            CanShoot = true;
        }
        else
        {
            CanShoot = false;
        }

        if (Time.timeScale != 0 && Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.J))
        {
            ani.SetBool("IsAtk", true);
            noCombo = 1f;
            Invoke("Shoot", 0.2f);

        }
        else if (noCombo<0)
        {
            ani.SetBool("IsAtk", false);
        }
    }
    void Shoot()
    {
        
        if (CanShoot == true && BC.bullet != 0)
        {
            // ���ͤl�u
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // ���o�l�u�����餸��
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            // �]�w�l�u���o�g�O�q
            bulletRigidbody.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

            BC.bullet -= 1;

            if (!skill.isUsingSkill)
            {
                float amount = 5f;
                sound.addSound(amount);
            }
        }
    }
}
