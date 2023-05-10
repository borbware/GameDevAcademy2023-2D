using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public enum DialogueState {
        Inactive,
        WritingMessage,
        FullMessage,
    }

    public DialogueState dialogueState;

    public static DialogueManager instance;
    public Message[] messages;

    int currentMessage;

    GameObject DialogueBox;
    TopDownMovement playerMovement;
    TextMeshProUGUI Name;
    Image ImageComponent;
    TextMeshProUGUI Sentence;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DialogueBox = transform.Find("DialogueBox").gameObject;
        Name = DialogueBox.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        ImageComponent = DialogueBox.transform.Find("Image").gameObject.GetComponent<Image>();
        Sentence = DialogueBox.transform.Find("Sentence").gameObject.GetComponent<TextMeshProUGUI>();;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownMovement>();

        SetInActive();
    }

    private void SetInActive()
    {
        dialogueState = DialogueState.Inactive;
        DialogueBox.SetActive(false);
    }

    public void StartDialogue(Message[] newMessages)
    {
        messages = newMessages;
        currentMessage = 0;

        DisplayCurrentMessage();

        DialogueBox.SetActive(true);

    }

    void DisplayCurrentMessage()
    {
        Name.text = messages[currentMessage].name;
        ImageComponent.sprite = messages[currentMessage].image;
        
        StopAllCoroutines();
        StartCoroutine(AdvanceText());
    }

    IEnumerator AdvanceText()
    {
        dialogueState = DialogueState.WritingMessage;
        Sentence.text = "";
        foreach(char character in messages[currentMessage].sentence.ToCharArray())
        {
            Sentence.text += character;
            yield return new WaitForSeconds(0.05f);
        }
        dialogueState = DialogueState.FullMessage;
    }

    public void SetNextSentence()
    {
        if (currentMessage < messages.Length - 1)
        {
            currentMessage++;
            DisplayCurrentMessage();
        }
        else
        {
            StopDialogue();
        }
    }
    public void StopDialogue()
    {
        SetInActive();
        playerMovement.Invoke("StartIdling",0.5f);
    }

    void Update()
    {
        if (dialogueState == DialogueState.FullMessage)
        {
            if (Input.GetButtonDown("Jump"))
            {
                SetNextSentence();
            }
        }
        else if (dialogueState == DialogueState.WritingMessage)
        {
            if (Input.GetButtonDown("Jump"))
            {
                StopAllCoroutines();
                Sentence.text = messages[currentMessage].sentence;
                dialogueState = DialogueState.FullMessage;
            }
        }
    }
}
