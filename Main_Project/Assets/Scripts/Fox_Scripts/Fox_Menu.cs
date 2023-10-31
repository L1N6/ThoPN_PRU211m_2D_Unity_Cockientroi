
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fox_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuFoxGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Exit()
    {
        
    }
}
