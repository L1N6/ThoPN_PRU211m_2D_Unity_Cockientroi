using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject VisualCue;
    [SerializeField] private TMP_Text DisplayName;
    private bool isOnRange = false;
    void Start()
    {
        VisualCue.SetActive(false);
        DisplayName.SetText(this.tag);
    }

    private void Update()
    {
        if(isOnRange)
        {
            VisualCue.SetActive(true);
        }
        else
        {
            VisualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            isOnRange = true;
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
