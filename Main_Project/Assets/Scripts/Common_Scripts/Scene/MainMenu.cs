using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator SceneTransition;
    [SerializeField] private GameObject SceneTransitionObject;

    private void Start()
    {
        SceneTransitionObject.SetActive(false);
    }
    public void PlayGame()
    {
        StartCoroutine(LoadTransitionScene());
    }

    private IEnumerator LoadTransitionScene()
    {
        SceneTransitionObject.SetActive(true);
        SceneTransition.Play("TransitionEnd");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Common_Scenes");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
