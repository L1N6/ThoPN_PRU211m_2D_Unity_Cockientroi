using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxGameManager : MonoBehaviour
{
    [SerializeField] GameObject winDialog;
    public GameObject[] players;

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) {
                aliveCount++;
            }
        }

        if (aliveCount <= 1) {
            //Invoke(nameof(NewRound), 3f);
            winDialog.SetActive(true);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
