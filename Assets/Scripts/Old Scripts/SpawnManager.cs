using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerUp;
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject[] turrets;

    public float zSpawn = 15.0f;
    public float xSpawnRange = 11.0f;

    private float startDelay = 1.0f;
    private float enemySpawnTime = 1.5f;
    private float obstacleSpawnTime = 2.0f;
    private float turretSpawnTime = 4.0f;
    private float powerUpSpawnTime = 15.0f;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomObstacle", startDelay, obstacleSpawnTime);
        InvokeRepeating("SpawnRandomTurret", startDelay, turretSpawnTime);
        InvokeRepeating("SpawnRandomPowerUp", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        isGameActive = FindObjectOfType<GameManager>().isGameActive;

        if (isGameActive == true)
        { 
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, 0, zSpawn -4);

            Instantiate(enemies[randomIndex],spawnPos,enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnRandomPowerUp()
    {
        isGameActive = FindObjectOfType<GameManager>().isGameActive;

        if (isGameActive == true)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, powerUp.Length);

            Vector3 spawnPos = new Vector3(randomX, 0, zSpawn);

            Instantiate(powerUp[randomIndex], spawnPos, powerUp[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnRandomObstacle()
    {
        isGameActive = FindObjectOfType<GameManager>().isGameActive;

        if (isGameActive == true)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, obstacles.Length);

            Vector3 spawnPos = new Vector3(randomX, -1, zSpawn);

            Instantiate(obstacles[randomIndex], spawnPos, obstacles[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnRandomTurret()
    {
        isGameActive = FindObjectOfType<GameManager>().isGameActive;

        if (isGameActive == true)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, turrets.Length);

            Vector3 spawnPos = new Vector3(randomX, -1.75f, zSpawn);

            Instantiate(turrets[randomIndex], spawnPos, turrets[randomIndex].gameObject.transform.rotation);
        }
    }
}
