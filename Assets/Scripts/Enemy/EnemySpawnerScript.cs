using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] public List<GameObject> spawnedEnemies = new List<GameObject>();
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
            if (currLevel == 1 && spawnedEnemies.Count <= 9)
            {
                SpawnEnemy();
            }
            else if (currLevel == 2 && spawnedEnemies.Count <= 14)
            {
                SpawnEnemy();
            }
            else if (currLevel == 3 && spawnedEnemies.Count <= 19)
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
        GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemies.Add(obj);
        //CheckAlive();
    }

    //if there are no more enemies to spawn in the level, display the level over screen
    public void EndLevel()
    {
        Time.timeScale = 0f;
        levelOverUI.SetActive(true);
    }

    //checks if there are any enemies alive
    public void CheckAlive()
    {
        //loop over list of spawned enemies to check if there is any alive before starting the next wave
        //reversed for loop
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            //check if entry is null, if true, remove from the list
            if (spawnedEnemies[i] == null)
            {
                spawnedEnemies.RemoveAt(i);
            }
        }
    }
}