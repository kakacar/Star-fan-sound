using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    public Alarm alarm;
    public GameObject[] spawnedBee;
    public GameObject[] spawnedCow;
    private Player player;
    private float t;

    void FixedUpdate()
    {
        t -= Time.deltaTime;
        if (alarm.warning && t <= 0)
        {
            SpawnEnemy();
        }
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }
    public void SpawnEnemy()
    {
        if (spawnedBee.Length != 0)
        {
            for (int i = 0; i < spawnedBee.Length; i++)
            {
                if (spawnedBee[i] != null)
                {
                    spawnedBee[i].GetComponent<Enemy>().hp = spawnedBee[i].GetComponent<Enemy>().maxHp;
                    spawnedBee[i].SetActive(true);
                    spawnedBee[i].GetComponent<Enemy>().hpSlider.SetActive(true);
                }
                else
                {
                    i++;
                }
            }
        }
        if(spawnedCow.Length != 0)
        {
            for (int i = 0; i < spawnedCow.Length; i++)
            {
                if (spawnedCow[i] != null)
                {
                    spawnedCow[i].GetComponent<EnemyC>().hp = spawnedCow[i].GetComponent<EnemyC>().maxHp;
                    spawnedCow[i].SetActive(true);
                    spawnedCow[i].GetComponent<EnemyC>().hpSlider.SetActive(true);
                }
                else
                {
                    i++;
                }
            }
        }
        t = 10;
    }
}