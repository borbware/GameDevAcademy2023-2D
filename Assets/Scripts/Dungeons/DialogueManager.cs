using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Message[] messages;

    GameObject DialogueBox;
    GameObject Name;
    GameObject Image;
    GameObject Sentence;

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
    }

    public void StartDialogue(Message[] newMessages)
    {
        messages = newMessages;
        DialogueBox.SetActive(true);
    }

    public void DisplayNextSentence()
    {

    }

    public void StopDialogue()
    {
        DialogueBox.SetActive(false);
    }
}
