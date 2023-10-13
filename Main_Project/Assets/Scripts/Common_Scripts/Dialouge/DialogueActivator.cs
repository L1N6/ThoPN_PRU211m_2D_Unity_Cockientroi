using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Toad") && collision.TryGetComponent(out ToadMovement toadMovement)) {
            toadMovement.Interactable= this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Toad") && collision.TryGetComponent(out ToadMovement toadMovement))
        {
            if(toadMovement.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                toadMovement.Interactable = null;  
            }
            toadMovement.Interactable = this;
        }
    }

    public void Interact(ToadMovement toadMovement)
    {
        if(TryGetComponent(out DialogueResponseEvents responseEvents))
        {
            toadMovement.DialogueUI.AddResponseEvents(responseEvents.Events);
        }
        toadMovement.DialogueUI.showDialogue(dialogueObject);
    }
}
