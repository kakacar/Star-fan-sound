using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public BulletCount bullet;
    private void Start()
    {
        bullet = GameObject.Find("Player").GetComponent<BulletCount>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(bullet.bulletCount >= bullet.maxBullet * 3)
        {
            Destroy(this.gameObject);
        }
        else
        {
            bullet.bulletCount += bullet.maxBullet;
        }
        Destroy(this.gameObject);
    }
}
