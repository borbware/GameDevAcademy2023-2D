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
            Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")
        );
        // rb.MovePosition(rb.position + displacement * Time.deltaTime * walkSpeed);
        rb.velocity = displacement * Time.deltaTime * walkSpeed;
        if (rb.velocity.magnitude > 0)
        {
            animator.Play("PlayerWalk");
        }
        else
        {
            animator.Play("PlayerIdle");
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        //ContactPoint2D hit = other.GetContact(0);
        //rb.velocity = Vector2.Reflect(rb.velocity, hit.normal);
    }
}
