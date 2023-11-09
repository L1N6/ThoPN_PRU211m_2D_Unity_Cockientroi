using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManagement;

public class FoxGameManager : MonoBehaviour
{
    //[SerializeField] GameObject winDialog;
    [SerializeField] GameObject PortalWin;
    public GameObject[] players;
    public GameObject[] enemys;
    private GameManagement gameManagement = new GameManagement();
    bool isWin = true;
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
        if (aliveCount == 0) {

            gameManagement.UpdateAnimalAfterLoseStatus(AfterLoseStatus.Fox_Waiting.ToString());
            SceneManager.LoadScene("Common_Scenes");
        }
        if (enemyCount == 0)
        {
            isWin= true;
            PortalWin.SetActive(true);
        }
    }

    //private void Update()
    //{
    //    if(players.Length == 0)
    //    {
    //        gameManagement.UpdateAnimalAfterLoseStatus(AfterLoseStatus.Fox_Waiting.ToString());
    //        SceneManager.LoadScene("Common_Scenes");
    //    }
    //}

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player")&& isWin)
        {
            gameManagement.UpdateAnimalWinStatus(Animal.Fox.ToString());
            SceneManager.LoadScene("Common_Scenes");
        }
    }
}
