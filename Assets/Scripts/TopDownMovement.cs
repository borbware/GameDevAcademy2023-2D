using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    Rigidbody2D rb;

    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    Vector2 displacement;
    void FixedUpdate()
    {
        displacement = new Vector2(
            Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")
        );
        displacement = Vector2.ClampMagnitude(displacement, 1);
        // rb.MovePosition(rb.position + displacement * Time.deltaTime * walkSpeed);
        rb.velocity = displacement * Time.deltaTime * walkSpeed;

        // ver 1
        animator.SetFloat("WalkSpeed", rb.velocity.magnitude);

        if (displacement.magnitude > 0.1f)
        {
            animator.SetFloat("XSpeed", displacement.x);
            animator.SetFloat("YSpeed", displacement.y);
        }
        
        // // ver 2 (ei toiminu :( )
        // if (rb.velocity.magnitude > 0)
        // {
        //     animator.SetTrigger("StartWalking");
        // }
        // else
        // {
        //     animator.SetTrigger("StartIdling");
        // }
        // ver 3
        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        // ver 0 (no controller)
        // if (rb.velocity.magnitude > 0)
        // {
        //     //animator.Play("PlayerWalk");
        // }
        // else
        // {
        //     //animator.Play("PlayerIdle");
        // }
    }

    void OnCollisionEnter2D(Collision2D other) {
        //ContactPoint2D hit = other.GetContact(0);
        //rb.velocity = Vector2.Reflect(rb.velocity, hit.normal);
    }
}
