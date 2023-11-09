using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxGameManager : MonoBehaviour
{
    [SerializeField] GameObject winDialog;
    public GameObject[] players;
    public GameObject[] enemys;
    public void CheckWinState()
    {
        int aliveCount = 0;
        int enemyCount = 0;
        foreach (GameObject player in players)
        {
            if (player.activeSelf) { 
                aliveCount++;
            }
        }
        foreach (GameObject enemy in enemys)
        {
            if (enemy.activeSelf)
            {
                enemyCount++;
            }
        }
        if (enemyCount == 0) {
            
            winDialog.SetActive(true);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
