using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCrabGameScene : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
