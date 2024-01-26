using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-142f, 492f), 519f, 0);
            Instantiate(enemy, transform.position+enemyspawn, Quaternion.identity,transform);
            yield return new WaitForSeconds(4);
        }
    }
}
