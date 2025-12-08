using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   [SerializeField] private NavMeshAgent agent;
   [SerializeField] private LevelTarget levelTarget;

   private void Start()
   {
      agent.SetDestination(levelTarget.targetPosition);
   }
}
