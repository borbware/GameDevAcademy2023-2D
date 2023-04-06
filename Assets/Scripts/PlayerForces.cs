using UnityEngine;

public class PlayerForces : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float maxAngularVelocity = 90;
    [SerializeField] float thrust = 90;
    [SerializeField] float torque = 90;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump")) { // continuous
            rb.AddForce(transform.up * thrust * Time.fixedDeltaTime);
        }

        float rotateInput = Input.GetAxisRaw("Horizontal");
        

        if ( Mathf.Abs(rb.angularVelocity) <= maxAngularVelocity )
        {
            rb.AddTorque(- rotateInput * Time.fixedDeltaTime * torque);
        }
        else
        {
            rb.angularVelocity = Mathf.Clamp(
                rb.angularVelocity,
                -maxAngularVelocity,
                maxAngularVelocity
            );
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);
    }


}
