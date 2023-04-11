using UnityEngine;

public class ShootTheBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotPosition;
    [SerializeField] float shotForce;
    [SerializeField] float lifeTime;
    [SerializeField] float shotPeriod;

    float shotTime = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && shotTime <= 0)
        {
            GameObject newBullet = Instantiate(bullet, shotPosition.position, transform.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * shotForce);
            Destroy(newBullet, lifeTime);
            shotTime = shotPeriod;
        }
        shotTime -= Time.deltaTime;
    }
}
