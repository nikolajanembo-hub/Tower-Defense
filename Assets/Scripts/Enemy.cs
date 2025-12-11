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
      if (other.CompareTag("EndPoint"))
      {
         StartCoroutine(EndGameRoutine());
      }
   }

   private void EndGame()
   { 
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

   private IEnumerator EndGameRoutine()
   {
      yield return new WaitForSeconds(1);
      EndGame();
   }
}
