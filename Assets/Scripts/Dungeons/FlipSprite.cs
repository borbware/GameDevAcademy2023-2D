using Pathfinding;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    AIPath aipath;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        aipath = transform.parent.gameObject.GetComponent<AIPath>();
    }

    void Update()
    {
        spriteRenderer.flipX = (aipath.desiredVelocity.x > 0.0f);
    }
}
