using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFOV : MonoBehaviour
{
    [SerializeField] public FieldOfView enemyFOV;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            enemyFOV.canSeePlayer = true;
        }
        else
        {
            enemyFOV.canSeePlayer = false;
        }
    }
}
