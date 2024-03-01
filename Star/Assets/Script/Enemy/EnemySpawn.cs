using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    public GameObject[] spawn;
    public Alarm alarm;
    private GameObject[] spawnedEnemy;
    private Player player;

    void FixedUpdate()
    {
        if (alarm.warning)
        {
            if (spawnedEnemy[0] == null || spawnedEnemy[1] == null)
            {
                SpawnEnemy();
            }
        }
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }
    public void SpawnEnemy()
    {
        if(spawnedEnemy[0] == null)
        {
            spawnedEnemy[0] = Instantiate(enemyPrefab, spawn[0].transform.position, Quaternion.identity);
        }
        else if(spawnedEnemy[1] == null)
        {
            spawnedEnemy[1] = Instantiate(enemyPrefab, spawn[1].transform.position, Quaternion.identity);
        }else if(player.transform.position.y < -2.5)
        {
            spawnedEnemy[0] = Instantiate(enemyPrefab, spawn[0].transform.position, Quaternion.identity);
            spawnedEnemy[1] = Instantiate(enemyPrefab, spawn[1].transform.position, Quaternion.identity);
        }
    }
}