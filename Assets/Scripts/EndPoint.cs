using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI playerHealthText;

    private void Awake()
    {
        endGamePanel.SetActive(false);
        playerHealthText.text = "Health " + playerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            playerHealth--;
            Destroy(other.gameObject); 
            playerHealthText.text = "Health " + playerHealth.ToString();
            if(playerHealth <= 0)
                { 
                    endGamePanel.SetActive(true); 
                    Time.timeScale = 0; //staje vreme timescale
                }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; // vreme se vraca
    }

}
