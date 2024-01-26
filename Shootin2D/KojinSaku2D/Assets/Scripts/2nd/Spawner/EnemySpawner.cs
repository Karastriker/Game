using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRate = 1.0f;
    public float spawnAreaHeight = 5.0f;

    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedPrefab = enemyPrefabs[randomIndex];

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
