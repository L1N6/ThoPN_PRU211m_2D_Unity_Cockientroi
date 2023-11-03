using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator SceneTransition;
    [SerializeField] private GameObject SceneTransitionObject;
    [SerializeField] AudioManager AudioManager;

    private void Start()
    {
        AudioManager.PlaySFX(AudioManager.ButtonClick);
        StartCoroutine(LoadTransitionSceneStart(1.0f));
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        AudioManager.PlaySFX(AudioManager.ButtonClick);
        StartCoroutine(LoadTransitionSceneEnd());
    }

    public void PlayGame()
    {
        StartCoroutine(LoadTransitionSceneEnd());
    }

    private IEnumerator LoadTransitionSceneEnd()
    {
        SceneTransitionObject.SetActive(true);
        SceneTransition.Play("TransitionEnd");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("Common_Scenes");
    }

    private IEnumerator LoadTransitionSceneStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneTransitionObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
