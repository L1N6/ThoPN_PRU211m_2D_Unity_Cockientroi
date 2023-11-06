using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResponseHandle : MonoBehaviour
{
    private GameObject Toad;
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private GameObject sceneTrasition;


    private DialogueUI dialogueUI;
    private ResponseEvent[] responseEvents;

    private List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
        Toad = GameObject.FindGameObjectWithTag("Toad");
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        this.responseEvents = responseEvents;
    }

    public void ShowResponses(Response[] responses)
    {
        sceneTrasition.SetActive(false);
        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

        float responseBoxHeight = 0;

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responseIndex));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;

        }


        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response, int responseIndex)
    {
        responseBox.gameObject.SetActive(false);
        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }

        if (responseEvents != null && responseIndex <= responseEvents.Length)
        {
            responseEvents[responseIndex].OnPickedResponse.Invoke();
            
        }

        if (response.Dialogue)
        {
            dialogueUI.showDialogue(response.Dialogue);
            StartCoroutine(YesButton(responseEvents, responseIndex));
        }
        else
        {
            dialogueUI.CloseDialogueBox();
        }
        responseEvents = null;

        tempResponseButtons.Clear();
        dialogueUI.showDialogue(response.Dialogue);
        

    }

    private IEnumerator TransitionScene()
    {
        sceneTrasition.SetActive(true);
        transitionAnimator.Play("TransitionEnd");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(DialogueTrigger.sceneName);
    }

    private IEnumerator YesButton(ResponseEvent[] responseEvents, int responseIndex) {
        yield return new WaitForSeconds(3);
        if (responseEvents[responseIndex].name.Equals("Yes"))
        {
            PlayerPrefs.SetFloat(GameManagement.ToadPositionX, Toad.transform.position.x);
            PlayerPrefs.SetFloat(GameManagement.ToadPositionY, Toad.transform.position.y);
            PlayerPrefs.SetFloat(GameManagement.ToadPositionZ, Toad.transform.position.z);
            PlayerPrefs.Save();
            StartCoroutine(TransitionScene());
        }
    }
}
