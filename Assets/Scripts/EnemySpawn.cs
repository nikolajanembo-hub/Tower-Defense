using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int spawnAmount;
    [SerializeField]private Vector2 spawndelayRange;
    [SerializeField] private float sphereSpawnRange;
    private int enemiesSpawned = 0;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (enemiesSpawned = 0; enemiesSpawned < spawnAmount; enemiesSpawned++)
        {
            yield return new WaitForSeconds(Random.Range(spawndelayRange.x, spawndelayRange.y));
            Instantiate(enemy,transform.position  + Random.insideUnitSphere*sphereSpawnRange,Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereSpawnRange);
    }
}
