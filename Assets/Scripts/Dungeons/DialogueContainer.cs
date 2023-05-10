using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    public Message[] messages;

    bool jumpInput;

    void Update()
    {
        if (Input.GetButton("Jump"))
            jumpInput = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TopDownMovement playerMovement = other.gameObject.GetComponent<TopDownMovement>();
            if (playerMovement.idleOrWalk && jumpInput)
            {
                DialogueManager.instance.StartDialogue(messages);
                playerMovement.playerState = TopDownMovement.PlayerState.Talk;
            }
        }
        jumpInput = false;
    }
}
