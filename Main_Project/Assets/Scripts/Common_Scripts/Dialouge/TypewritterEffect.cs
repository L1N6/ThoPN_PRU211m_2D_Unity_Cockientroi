using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TypewritterEffect : MonoBehaviour
{
    [SerializeField] private float TypewritterSpeed = 50f;
    public bool isRunning { get; private set; }

    private readonly List<Punctuation> punctuations = new List<Punctuation>()
    {
        new Punctuation(new HashSet<char>(){'.','!','?'}, 0.6f),
        new Punctuation(new HashSet<char>(){',',';',':'}, 0.3f)
    };

    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLable)
    {
        typingCoroutine = StartCoroutine(TypeText(textToType, textLable));
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        isRunning = false;
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLable)
    {
        isRunning = true;
        textLable.text = string.Empty;

        float time = 0f;
        int charIndex = 0;
        while (charIndex < textToType.Length)
        {

            int lastCharIndex = charIndex;

            time += Time.deltaTime * TypewritterSpeed;

            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;
                textLable.text = textToType.Substring(0, i + 1);
                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }

            }

            yield return null;
        }

        isRunning = false;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (Punctuation puntuationCategory in punctuations)
        {
            if (puntuationCategory.Punctuations.Contains(character))
            {
                waitTime = puntuationCategory.WaitTime;
                return true;
            }
        }
        waitTime = default;
        return false;
    }

    private readonly struct Punctuation
    {
        public readonly HashSet<char> Punctuations;
        public readonly float WaitTime;



        public Punctuation(HashSet<char> punctuations, float waitTime) 
        {
            Punctuations = punctuations;
            WaitTime = waitTime;
        }
    }

}
