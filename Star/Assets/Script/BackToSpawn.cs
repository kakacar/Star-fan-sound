using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    public Player player;
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
        {
            player.transform.position = player.spawn.transform.position;
        }
    }
}
