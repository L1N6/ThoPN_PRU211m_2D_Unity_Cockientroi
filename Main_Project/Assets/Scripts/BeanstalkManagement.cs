using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeanstalkManagement : MonoBehaviour
{
    [SerializeField] private Animator SceneTransition;

    public void GoToBeanstalk()
    {
        StartCoroutine(changeThunderermap());
    }
    public IEnumerator changeThunderermap()
    {
        SceneTransition.gameObject.SetActive(true);
        SceneTransition.Play("TransitionEnd");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ChangeThundererScene");
    }
}
