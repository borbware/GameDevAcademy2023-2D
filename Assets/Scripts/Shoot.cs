using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletLifeTime;
    [SerializeField] Transform shotPosition;
    [SerializeField] float shotForce;

    public void ShootABullet(float rotation)
    {
        Quaternion newRotation = Quaternion.Euler(0, 0, rotation);

        GameObject newBullet = Instantiate(
            bullet,
            shotPosition.position,
            newRotation * transform.rotation  // rotate transform by newRotation
        );
        
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        // force direction is rotated by newRotation as well
        bulletRb.AddForce(
            newRotation * transform.up * shotForce
        );
        Destroy(newBullet, bulletLifeTime);
    }
}
