using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

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
        }
    }

    public void Interact(ToadMovement toadMovement)
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>()) 
        {
            if(responseEvents.DialogueObject == dialogueObject)
            {
                toadMovement.DialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }
        toadMovement.DialogueUI.showDialogue(dialogueObject);
    }
}
