using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    public GameObject spawn;
    public Alarm alarm;
    private GameObject spawnedEnemy;
    private Player player;

    void Update()
    {
        if (IsOutsideCameraView() && alarm.warning)
        {
            StartCoroutine(SpawnEnemy());
        }
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    bool IsOutsideCameraView()
    {
        Vector3 enemyScreenPos = mainCamera.WorldToScreenPoint(spawn.transform.position);
        return enemyScreenPos.x < 0 || enemyScreenPos.x > Screen.width || enemyScreenPos.y < 0 || enemyScreenPos.y > Screen.height;
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5);
        spawnedEnemy = Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<FieldOfView>().PatrolPoints[0] = player.collectingPoint.transform;
    }
}
