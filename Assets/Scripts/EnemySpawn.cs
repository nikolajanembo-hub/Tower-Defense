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
    [SerializeField]private Vector2 spawndelayRange;
    [SerializeField] private float sphereSpawnRange;
    [SerializeField] private Button spawnButton;
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private List<Wave> waves;
    [SerializeField] private float waveLenght;
    [SerializeField] private TextMeshProUGUI waveTimerText;
    [SerializeField] private Inventory inventory;
    [SerializeField] private EnemyTracker enemyTracker;
    
    private bool isTimerActive;
    private float waveTimer;
    private int currentWave;

    private void Awake()
    {
        waveNumberText.text = "Wave: " + currentWave + "/" + waves.Count.ToString();
        waveTimerText.text = " ";
        enemyTracker.Init();
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
        foreach (Wave.SpawnType type in waves[currentWave].types)
        {
            for (int i = 0; i < type.count; i++)
            {
                yield return new WaitForSeconds(Random.Range(spawndelayRange.x, spawndelayRange.y));
                Instantiate(type.type,transform.position  + Random.insideUnitSphere*sphereSpawnRange,Quaternion.identity);
            }
        }
        currentWave++;
        if (currentWave < waves.Count)
        {
            spawnButton.gameObject.SetActive(true);
            StartCoroutine(WaveTimer());
        }
        else
        {
            enemyTracker.EnemyCountChanged += EndGameCheck;
        }
       // Skriptal object enemy tracker koji se povecava kad se spawn smanja kad se skida Coin za enemy bukvalno i na promenu enemy subscribe enemy spawner 
    }

    private void EndGameCheck()
    {
        if (enemyTracker.Enemies.Count == 0)
        {
            Debug.Log("Level complete");
        }
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

    [Serializable] public class Wave
    {
        public List<SpawnType> types = new List<SpawnType>();

        public int Count
        {
            get
            {
                int counter = 0;
                foreach (SpawnType type in types)
                    counter += type.count;
                return counter;
            }
        }

        [Serializable] public class SpawnType
        {
            public Enemy type;
            public int count;
        }
    }
}
