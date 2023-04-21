using UnityEngine;

public class ShootInSight : MonoBehaviour
{

    [SerializeField] float windUpTime;

    Shoot shoot;

    float windUpTimer = 0;

    void Start()
    {
        shoot = transform.parent.GetComponent<Shoot>();
    }

    void Update()
    {
        windUpTimer -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (windUpTimer <= 0 && other.gameObject.tag == "Player")
        {
            windUpTimer = windUpTime;
            shoot.ShootABullet(180);
        }
    }
}
