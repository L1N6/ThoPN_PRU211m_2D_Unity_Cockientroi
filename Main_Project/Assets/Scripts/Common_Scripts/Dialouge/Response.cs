
using System;
using UnityEngine;

[System.Serializable]
public class Response 
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogue;

    public string ResponseText => responseText;
    public DialogueObject Dialogue => dialogue;
}
