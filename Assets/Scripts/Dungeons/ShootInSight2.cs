using UnityEngine;

public class ShootInSight2 : MonoBehaviour
{
    [SerializeField] float windUpTime;
    void Shoot()
    {
        transform.parent.SendMessage("ShootABullet", 180);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("Shoot", 0f, windUpTime);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("Shoot");
        }
    }
}
