using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private int spawnedEnemies;

    [SerializeField] private GameObject enemyPrefab;

    //start function to start the Coroutine
    private void Start()
    {
        StartCoroutine(spawner());
    }

    //spawner for spawning the enemies at the set spawnrate
    private IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            SpawnEnemy();
            yield return wait;
        }
    }

    //Instantiate the enemy prefab so that the enemies spawn
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
