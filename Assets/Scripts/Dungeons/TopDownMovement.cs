using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    Rigidbody2D rb;

    enum PlayerState {
        Hurt,
        Idle,
        Walk
    }
    [SerializeField] int hp = 8;
    [SerializeField] PlayerState playerState = PlayerState.Idle;

    Animator animator;
    void Start()
    {
        if (DungeonMaster.instance.spawnLocationName != "")
        {
            GameObject spawnLocation = GameObject.Find(DungeonMaster.instance.spawnLocationName);
            transform.position = spawnLocation.transform.position;
        }
        rb = GetComponent<Rigidbody2D>();
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
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (playerState != PlayerState.Hurt && other.gameObject.tag == "Bullet")
        {
            playerState = PlayerState.Hurt;
            hp -= 1;
        }
    }
}
