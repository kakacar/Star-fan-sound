using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Camera mainCamera;
    public GameObject spawn;
    public Alarm alarm;

    void Update()
    {
        if (IsOutsideCameraView() && alarm.warning)
        {
            StartCoroutine(SpawnEnemy());
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
        Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
    }
}
