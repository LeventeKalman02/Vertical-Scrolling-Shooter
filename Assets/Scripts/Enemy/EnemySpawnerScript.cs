using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private int spawnedEnemies;
    [SerializeField] private int currLevel = 1;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject levelOverUI;
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
            //check to set the amount of enemies that can spawn in a level, This can be changed in the editor for each level.
            if (currLevel == 1 && spawnedEnemies <= 9)
            {
                SpawnEnemy();
            }
            else if (currLevel == 2 && spawnedEnemies <= 14)
            {
                SpawnEnemy();
            }
            else if (currLevel == 3 && spawnedEnemies <= 19)
            {
                SpawnEnemy();
            }
            else
            {
                //EndLevel();
                break;
            }

            yield return wait;
        }
    }

    //Instantiate the enemy prefab so that the enemies spawn
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemies++;
    }

    //if there are no more enemies to spawn in the level, display the level over screen
    public void EndLevel()
    {
        Time.timeScale = 0f;
        levelOverUI.SetActive(true);
    }
}
