using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyspawnPrefab;
    public GameObject EnemyEliteSpawnPrefab;
    public GameObject EnemyFleetTwoSpawnPrefab;
    public GameObject EnemyFleetThreeSpawnPrefab;
    public GameObject EnemyFleetThreeEliteSpawnPrefab;
    
    public Vector3 spawnOffset = new Vector3(0f, 50f);

    public float spawnInterval = 10f;
    private float timeOfLastSpawn;

    void Start()
    {
        Instantiate(EnemyspawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        timeOfLastSpawn = Time.time;
    }


    void Update()
    {
        //spawns first type of enemies
        if (CanSpawn() && NewEnemies.instance.enemiesKilled <= 10)
        {
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyspawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }

        //spawn elite type of first enemy
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 10 && NewEnemies.instance.enemiesKilled <= 30)
        {
            spawnInterval = 8;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyEliteSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
        //spawn second type of enemies
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 30 && NewEnemies.instance.enemiesKilled <= 45)
        {
            spawnInterval = 12;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyFleetTwoSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
        //spawn second type of enemies faster
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 45 && NewEnemies.instance.enemiesKilled <= 55)
        {
            spawnInterval = 10;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyFleetTwoSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
        //spawn third type of enemies
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 55 && NewEnemies.instance.enemiesKilled <= 65)
        {
            spawnInterval = 14;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyFleetThreeSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
        //spawn third type of enemies too fast
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 65 && NewEnemies.instance.enemiesKilled <= 75)
        {
            spawnInterval = 12;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyFleetThreeSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
        //spawn strong version of third type of enemies too fast 
        if (CanSpawn() && NewEnemies.instance.enemiesKilled >= 75)
        {
            spawnInterval = 10;
            timeOfLastSpawn = Time.time;
            Instantiate(EnemyFleetThreeEliteSpawnPrefab, transform.position + spawnOffset, Quaternion.identity);
        }
    }

    bool CanSpawn()
    {
        return Time.time - spawnInterval > timeOfLastSpawn;
    }

}
