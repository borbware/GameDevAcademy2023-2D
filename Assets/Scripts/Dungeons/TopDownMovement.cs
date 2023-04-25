using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    enum PlayerState {
        Hurt,
        Idle,
        Walk
    }
    [SerializeField] int hp = 8;
    [SerializeField] float hurtForce = 2;
    [SerializeField] float hurtTime = .3f;
    [SerializeField] PlayerState playerState = PlayerState.Idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    Vector2 displacement;
    void SetDirectBlendTreeValues()
    {
        //unused
        float angle = Mathf.Atan2(displacement.y, displacement.x) *  Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        if (playerState == PlayerState.Idle || playerState == PlayerState.Walk)
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
            if (rb.velocity.magnitude > 0)
            {
                playerState = PlayerState.Walk;
                animator.SetBool("Walk", true);
            }
            else
            {
                playerState = PlayerState.Idle;
                animator.SetBool("Walk", false);
            }
        }
        else if (playerState == PlayerState.Hurt)
        {
            sr.enabled = (Time.time % .1 < .05);
        }
    }
    void StartIdling()
    {
        playerState = PlayerState.Idle;
        sr.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerState != PlayerState.Hurt && other.gameObject.tag == "Bullet")
        {
            rb.AddForce(- rb.velocity.normalized * hurtForce, ForceMode2D.Impulse);
            playerState = PlayerState.Hurt;
            hp -= 1;
            Invoke("StartIdling",hurtTime);
        }
    }
}
