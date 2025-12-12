using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnAmount;
    private int enemiesSpawned = 0;
    [SerializeField]private Vector2 spawndelayRange;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (enemiesSpawned = 0; enemiesSpawned < spawnAmount; enemiesSpawned++)
        {
            yield return new WaitForSeconds(Random.Range(spawndelayRange.x, spawndelayRange.y));
            Instantiate(enemy,transform.position,Quaternion.identity);
        }
    }
}
