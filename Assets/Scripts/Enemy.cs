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
   private void Start()
   {
      agent.SetDestination(levelTarget.targetPosition);
   }

   private void OnDestroy()
   {
      inventory.Coins++;
   }
}
