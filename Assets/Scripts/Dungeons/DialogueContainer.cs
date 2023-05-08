using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    public Message[] messages;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButtonDown("Fire1"))
        {
            DialogueManager.instance.StartDialogue(messages);
        }
    }
}
