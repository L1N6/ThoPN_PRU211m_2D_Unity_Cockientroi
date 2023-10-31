using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBeeMap : MonoBehaviour
{
    [SerializeField] SwitchPlayer switchPlayer;
    [SerializeField] GameObject BeeDialogue;
    [SerializeField] MapChange mapChange;
    private GameManagement gameManagement;
    void Start()
    {
        gameManagement = new GameManagement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Toad"))
        {
            switchPlayer.UpdateLockKeyCode();
        }
        mapChange.UpdateEnd();
        BeeDialogue.SetActive(true);
    }

    public void BackToCommonMap()
    {
        gameManagement.UpdateAnimalWinStatus(GameManagement.Animal.Bee.ToString());
        SceneManager.LoadScene("Common_Scenes");
    }
}
