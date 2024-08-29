using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] public List<GameObject> spawnedEnemies = new List<GameObject>();
    public GameObject enemies;


    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject levelOverUI;

    //start function to start the Coroutine
    private void Start()
    {
        StartCoroutine(spawner());
    }

    private void Update()
    {
        //check for enemies with the tag "Enemy"
        enemies = GameObject.FindWithTag("Enemy");
      
    }

    //spawner for spawning the enemies at the set spawnrate
    private IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        //while enemies can spawn
        while (canSpawn)
        {
            //spawn 10 enemies
            if (spawnedEnemies.Count <= 9)
            {
                SpawnEnemy();
            }
            //once all enemies are killed, end level
            else if (enemies == null)
            {
                EndLevel();
            }

            yield return wait;
        }
    }

    //Instantiate the enemy prefab so that the enemies spawn
    private void SpawnEnemy()
    {
        GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnedEnemies.Add(obj);
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
