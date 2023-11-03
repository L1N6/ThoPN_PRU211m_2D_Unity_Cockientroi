using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ManageVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    [SerializeField] private string sceneChangeName;
    [SerializeField] private Animator sceneTransition;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(PlayTransitionAndChangeScene());
    }

    private IEnumerator PlayTransitionAndChangeScene()
    {
        sceneTransition.gameObject.SetActive(true);
        sceneTransition.Play("TransitionEnd");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneChangeName);
    }


}
