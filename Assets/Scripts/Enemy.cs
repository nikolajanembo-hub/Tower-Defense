using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   [SerializeField] private NavMeshAgent agent;
   [SerializeField] private LevelTarget levelTarget;

   private void Start()
   {
      agent.SetDestination(levelTarget.targetPosition);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "EndPoint")
      {
         EndGame();
      }
   }

   private void EndGame()
   { 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
