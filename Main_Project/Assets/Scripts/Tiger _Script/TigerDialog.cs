using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TigerDialog : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _dialogueLines;
    private int _lineIndex;
    private TMP_Text _text;
    private CanvasGroup _group;
    private bool _started;
    GameObject dialogue;
    private void Start()
    {
        dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        _text.SetText(_dialogueLines[0]);
        _group.alpha = 1;
    }

    private void OnValidate()
    {
        if (_dialogueLines.Count > 0)
        {
            if (_text == null) _text = GetComponent<TMP_Text>();
            _text.SetText(_dialogueLines[0]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_lineIndex < _dialogueLines.Count)
            {
                _text.SetText(_dialogueLines[_lineIndex++]);
                _group.alpha = 1;
            }
            else
            {
                dialogue.SetActive(false);
            }
        }
    }

}
