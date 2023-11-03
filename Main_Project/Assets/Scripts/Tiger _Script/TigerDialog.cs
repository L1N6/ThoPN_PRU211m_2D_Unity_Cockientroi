using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    public string title;
    private void Start()
    {
        switch (title)
        {
            case "start":
                dialogue = GameObject.FindGameObjectWithTag("Dialogue");
                break;
            case "game over":
                dialogue = GameObject.FindGameObjectWithTag("GameOverDialogue");
                dialogue.SetActive(false);
                break;
            case "victory":
                dialogue = GameObject.FindGameObjectWithTag("FinalDialogue");
                dialogue.SetActive(false);
                break;
            default:
                break;
        }

        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
        _started = true;
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
        if (_started)
        {
            _lineIndex = 0;
            _text.SetText(_dialogueLines[_lineIndex]);
            _group.alpha = 1;
            _started = false;

        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _lineIndex++;
            if (_lineIndex < _dialogueLines.Count)
            {
                _text.SetText(_dialogueLines[_lineIndex]);
                _group.alpha = 1;
            }
            else
            {
                dialogue.SetActive(false);
                if (title == "game over" || title == "victory")
                {
                    SceneManager.LoadScene("Common_Scenes");
                }
            }
        }
    }

}
