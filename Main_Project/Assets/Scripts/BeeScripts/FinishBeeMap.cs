using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBeeMap : MonoBehaviour
{
    private GameManagement gameManagement;
    [SerializeField] SwitchPlayer switchPlayer;
    [SerializeField] GameObject BeeDialogue;
    [SerializeField] GameObject Guide;
    [SerializeField] MapChange mapChange;
    
    void Start()
    {
        gameManagement = new GameManagement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bee"))
        {
            mapChange.UpdateEnd();
        }
        if(collision.gameObject.CompareTag("Toad") && PlayerPrefs.GetInt("FlowerCount") == 6)
        {
            Guide.SetActive(false);
            switchPlayer.UpdateLockKeyCode();
            BeeDialogue.SetActive(true);
        } 
    }

    public void Win()
    {
        gameManagement.UpdateAnimalWinStatus(GameManagement.Animal.Bee.ToString());
        SceneManager.LoadScene("Common_Scenes");
    }

    public void Lose()
    {
        gameManagement.UpdateAnimalAfterLoseStatus(GameManagement.AfterLoseStatus.Bee_Waiting.ToString());
        SceneManager.LoadScene("Common_Scenes");
    }

}
