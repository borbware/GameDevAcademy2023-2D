using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    Rigidbody2D rb;
    ParticleSystem particles;
    [SerializeField] float maxAngularVelocity = 90;
    [SerializeField] float maxAngularVelocityWhenShooting = 90;
    [SerializeField] float maxVelocity = 100;
    [SerializeField] float thrust = 90;
    [SerializeField] float torque = 90;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        particles = gameObject.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump")) { // continuous
            if (rb.velocity.magnitude < maxVelocity)
                rb.AddForce(transform.up * thrust * Time.fixedDeltaTime);
            else
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
            if (!particles.isEmitting)
                particles.Play();
        }
        else
        {
            if (particles.isEmitting)
                particles.Stop();
        }

        float rotateInput = Input.GetAxisRaw("Horizontal");
        
        float appliedMaxAngularVelocity = 
            (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
                ? maxAngularVelocityWhenShooting
                : maxAngularVelocity; 
        if ( Mathf.Abs(rb.angularVelocity) <= appliedMaxAngularVelocity)
            rb.AddTorque(- rotateInput * Time.fixedDeltaTime * torque);
        else
            rb.angularVelocity = Mathf.Clamp(
                rb.angularVelocity,
                -appliedMaxAngularVelocity,
                appliedMaxAngularVelocity
            );
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            AsteroidsGameManager.instance.AddLives(-1);
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }    
}
