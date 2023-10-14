using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLable;
    [SerializeField] private DialogueObject dialogueObject;

    public bool IsOpen { get; private set; }

    private ResponseHandle responseHandle;
    private TypewritterEffect typewritterEffect;

    private void Start()
    {
        CloseDialogueBox();
        //showDialogue(dialogueObject);
        responseHandle = GetComponent<ResponseHandle>();
        typewritterEffect = GetComponent<TypewritterEffect>();
    }

    public void showDialogue(DialogueObject dialogue)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialouge(dialogue));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandle.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialouge(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);

            textLable.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses)
            {
                break;
            }

            yield return null;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Tab));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandle.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }   
    }

    private IEnumerator RunTypingEffect(string dialouge)
    {
        typewritterEffect.Run(dialouge, textLable);

        while(typewritterEffect.IsRunning)
        {
            yield return null;

            if(Input.GetKeyDown(KeyCode.Tab))
            {
                typewritterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLable.text = string.Empty;
    }
}
