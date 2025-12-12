using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{
    [SerializeField] private int playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            playerHealth--;
            Destroy(other.gameObject);
            if(playerHealth <= 0)
                { 
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
        }
    }
    
}
