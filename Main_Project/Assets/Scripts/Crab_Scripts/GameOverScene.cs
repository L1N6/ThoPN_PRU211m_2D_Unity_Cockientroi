using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    private GameManagement gameManagement;
    void Start()
    {
        gameManagement = new GameManagement();
    }

    public void QuitGame()
    {
        gameManagement.UpdateAnimalWinStatus(GameManagement.Animal.Crab.ToString());
        SceneManager.LoadScene("Common_Scenes");    
    }

    public void Continue()
    {
        gameManagement.UpdateAnimalAfterLoseStatus(GameManagement.AfterLoseStatus.Crab_Waiting.ToString());
        SceneManager.LoadScene("Common_Scenes");
    }
}
