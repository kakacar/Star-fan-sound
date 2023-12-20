using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public class SetAtkAni : MonoBehaviour
    {
        [SerializeField] private AnimatorOverrideController[] OverrideControllers;
        [SerializeField] private AniOveride overrider;
        [SerializeField] private RuntimeAnimatorController[] Animators;
        [SerializeField] Player player;

        public GameObject weaponHolderR;
        public GameObject weaponHolderL;

        public GameObject CurrentweaponR;
        public GameObject CurrentweaponL;
        public GameObject[] Weapon;

        public RawImage skillUI;
        public Texture[] weaponImages;

        void Start()
        {
            CurrentweaponR = null;
            CurrentweaponL = null;

            //Àq»{ªZ¾¹¬°ºj
            SwitchGun();
        }
        void Update()
        {
            AnimatorSwitch();
            if(skillUI == null)
            {
                skillUI = GameObject.Find("WeaponUI").GetComponent<RawImage>();
            }
        }

        void AnimatorSwitch()
        {
            
            if (Input.GetKeyDown(KeyCode.Alpha2) && skillUI.texture == weaponImages[0])
            {
                SwitchSword();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && skillUI.texture == weaponImages[1])
            {
                SwitchGun();
            }
        }


        void SwitchGun()
        {
            skillUI.texture = weaponImages[0];
            overrider.Ani.runtimeAnimatorController = Animators[1] as RuntimeAnimatorController;
            player.CanAss = false;

            Destroy(CurrentweaponR);
            Destroy(CurrentweaponL);

            CurrentweaponR = Instantiate(Weapon[1], weaponHolderR.transform);
            CurrentweaponR.transform.localPosition = new Vector3(0.046f, -0.217f, 0.024f);
            CurrentweaponR.transform.localRotation = Quaternion.Euler(-0.345f, -167f, -90.9f);
        }

        void SwitchSword()
        {
            skillUI.texture = weaponImages[1];
            overrider.Ani.runtimeAnimatorController = Animators[0] as RuntimeAnimatorController;
            player.CanAss = true;
            Destroy(CurrentweaponR);
            Destroy(CurrentweaponL);

            CurrentweaponR = Instantiate(Weapon[0], weaponHolderR.transform);
            CurrentweaponR.transform.localPosition = new Vector3(0.002f, 0.009f, 0.015f);
            CurrentweaponR.transform.localRotation = Quaternion.Euler(-180f, -1f, 1.4f);

            CurrentweaponL = Instantiate(Weapon[0], weaponHolderL.transform);
            CurrentweaponL.transform.localPosition = new Vector3(0.008f, 0.041f, 0.018f);
            CurrentweaponL.transform.localRotation = Quaternion.Euler(6f, 2.1f, -177f);
        }

        void SwitchSword1()
        {
            skillUI.texture = weaponImages[1];
            overrider.Ani.runtimeAnimatorController = Animators[2] as RuntimeAnimatorController;
            player.CanAss = true;

            Destroy(CurrentweaponR);
            Destroy(CurrentweaponL);

            CurrentweaponR = Instantiate(Weapon[0], weaponHolderR.transform);
            CurrentweaponR.transform.localPosition = new Vector3(0f, 0.076f, 0.012f);
            CurrentweaponR.transform.localRotation = Quaternion.Euler(-180f, -1f, 1.4f);

            CurrentweaponL = Instantiate(Weapon[0], weaponHolderL.transform);
            CurrentweaponL.transform.localPosition = new Vector3(0.004f, 0.072f, 0.023f);
            CurrentweaponL.transform.localRotation = Quaternion.Euler(6f, 2.1f, -177f);
        }
    }
}

