using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject VisualCue;
    [SerializeField] private GameObject PressIcon;
    [SerializeField] private TMP_Text DisplayName;
    [SerializeField] private GetAvatar avatar;

    public static string sceneName { get; set; }

    private bool isOnRange = false;
    void Start()
    {
        VisualCue.SetActive(false);
        PressIcon.SetActive(true);
    }

    private void Update()
    {
        if (isOnRange)
        {
            VisualCue.SetActive(true);
            PressIcon.SetActive(false);
        }
        else
        {
            VisualCue.SetActive(false);
            PressIcon.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            isOnRange = true;
            avatar.SetAvatar(this.tag);
            DisplayName.SetText(this.tag);
            sceneName = this.tag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            isOnRange = false;
        }
    }


}
