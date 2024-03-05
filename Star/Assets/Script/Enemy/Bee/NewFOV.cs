using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static FieldOfView;

public class NewFOV : MonoBehaviour
{
    [SerializeField] public FieldOfView enemyFOV;
    [SerializeField] public Enemy enemy;

    public bool BeStab;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (enemy.enemyDead == false)
            {
                if (!enemyFOV.BeStab)
                {
                    enemyFOV.canSeePlayer = true;
                    enemyFOV.HeadLt.color = new Color(255f, 0f, 0f);
                    enemyFOV.lostPlayer = enemyFOV.lostChase;
                    enemyFOV.distanceToTarget = Vector3.Distance(enemy.transform.position, other.transform.position);
                }
            }
        }
        else
        {
            enemyFOV.StopChase();
        }
    }
}
