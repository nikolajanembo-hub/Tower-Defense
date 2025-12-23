using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   [SerializeField] private NavMeshAgent agent;
   [SerializeField] private LevelTarget levelTarget;
   [SerializeField] private Inventory inventory;
   [SerializeField] private EnemyTracker enemyTracker;
   [SerializeField] private int health;
   
   private void Start()
   {
      agent.SetDestination(levelTarget.targetPosition);
      enemyTracker.AddEnemy(this);
   }

   private void OnDestroy()
   {
      inventory.Coins++;
      enemyTracker.RemoveEnemy(this);
   }

   public void Hit(int damage)
   {
      health -= damage;
      if (health <= 0)
      {
         Destroy(gameObject);
      }
   }
}
