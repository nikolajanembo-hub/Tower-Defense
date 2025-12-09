using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnAmount;
    private int enemiesSpawned = 0;
    private void Start()
    {
       SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (enemiesSpawned = 0; enemiesSpawned < spawnAmount; enemiesSpawned++)
        {
            Instantiate(enemy,transform.position,Quaternion.identity);
        }
    }
}
