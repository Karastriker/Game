using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerSide : MonoBehaviour
{
    public GameObject enemySide;
    public float distanceBetweenEnemies = 1.7f;
    public int numberOfEnemies = 3;
    public float spawnRate = 1.0f;

    private float spawnTimer;

    IEnumerator Start()
    {
        while(true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnRate);
        }
    }
    void SpawnEnemies()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + Vector2.left * i * distanceBetweenEnemies
                + Vector2.down * i * distanceBetweenEnemies;
            Instantiate(enemySide, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
