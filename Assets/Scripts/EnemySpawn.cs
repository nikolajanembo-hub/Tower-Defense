using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField]private Vector2 spawndelayRange;
    [SerializeField] private float sphereSpawnRange;
    [SerializeField] private Button spawnButton;
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private List<int> waves;
    [SerializeField] private float waveLenght;
    [SerializeField] private TextMeshProUGUI waveTimerText;
    [SerializeField] private Inventory inventory;
    
    private bool isTimerActive;
    private float waveTimer;
    private int currentWave;

    private void Awake()
    {
        waveNumberText.text = "Wave: " + currentWave + "/" + waves.Count.ToString();
        waveTimerText.text = " ";
    }

    private void OnEnable()
    {
        spawnButton.onClick.AddListener(StartSpawning);
    }

    private void OnDisable()
    {
        spawnButton.onClick.RemoveListener(StartSpawning);
    }

    private IEnumerator SpawnEnemies()
    {
        isTimerActive = false;
        spawnButton.gameObject.SetActive(false);
        waveNumberText.text = "Wave: " + (currentWave + 1) + "/" + waves.Count.ToString();
        for (int enemiesSpawned = 0; enemiesSpawned < waves[currentWave]; enemiesSpawned++)
        {
            yield return new WaitForSeconds(Random.Range(spawndelayRange.x, spawndelayRange.y));
            Instantiate(enemy,transform.position  + Random.insideUnitSphere*sphereSpawnRange,Quaternion.identity);
        }
        spawnButton.gameObject.SetActive(true);
        currentWave++;
        StartCoroutine(WaveTimer());
    }

    private IEnumerator WaveTimer()
    {
        isTimerActive = true;
        waveTimer = Time.time + waveLenght;
        while (isTimerActive && waveTimer > Time.time)
        {
            yield return null;
            waveTimerText.text = "Next wave in: " + (waveTimer - Time.time).ToString("F0"); 
        }
        waveTimerText.text = " ";

        if (isTimerActive == true)
        {
            StartSpawning();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereSpawnRange);
    }

    private void StartSpawning()
    {
        if (currentWave < waves.Count)
        {
            if (waveTimer > Time.time)
            {
                inventory.Coins += (int)(waveTimer - Time.time);
            }
            StartCoroutine(SpawnEnemies());
        }
    }
}
