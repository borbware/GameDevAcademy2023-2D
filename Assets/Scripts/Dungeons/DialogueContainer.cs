using UnityEngine;

public class DialogueContainer : MonoBehaviour
{
    public Message[] messages;

    bool jumpInput;

    void Update()
    {
        jumpInput = Input.GetButton("Jump");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TopDownMovement playerMovement = other.gameObject.GetComponent<TopDownMovement>();
            if (
                (
                    playerMovement.playerState == TopDownMovement.PlayerState.Idle
                    || playerMovement.playerState == TopDownMovement.PlayerState.Walk
                )
            && jumpInput)
            {
                DialogueManager.instance.StartDialogue(messages);
                playerMovement.playerState = TopDownMovement.PlayerState.Talk;
                Debug.Log("asdf");
            }
        }
    }
}
