using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnpoint;
    public float firstSpawnTime = 5f;
    public float spawnTime = 15f;

    void Update()
    {
        firstSpawnTime -= Time.deltaTime;

        if (firstSpawnTime <= 0.0f)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawnpoint.position, enemySpawnpoint.rotation);

            firstSpawnTime = spawnTime;
        }
    }
}
