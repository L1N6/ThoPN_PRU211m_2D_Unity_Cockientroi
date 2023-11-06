
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fox_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    bool isWin=false;
    GameManagement gamefox=new GameManagement();
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
        if (isWin)
        {
            gamefox.UpdateAnimalWinStatus(GameManagement.Animal.Fox.ToString());
            SceneManager.LoadScene("Common_Scenes");
        }
        else
        {
            gamefox.UpdateAnimalAfterLoseStatus(GameManagement.Animal.Fox.ToString());
            SceneManager.LoadScene("Common_Scenes");
            
        }
        
    }
    public void UpdateWinStatus()
    {
        isWin= true;      
    }
}
