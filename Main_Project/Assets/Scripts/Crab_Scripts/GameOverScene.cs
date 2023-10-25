using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("Crab_Scenes");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Common_Scenes");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Common_Scenes");
    }
}
