using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
    [SerializeField] GameObject tinyAsteroid;

    [SerializeField] int hp;
    [SerializeField] float hurtPeriod;
    [SerializeField] float bulletPushForce;
    [SerializeField] float initTorque;
    [SerializeField] float initForce;
    float hurtTime = 1f;
    Renderer rend;
    Rigidbody2D rb;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddTorque(Random.Range(-1f, 1f) * initTorque);
        rb.AddForce(Random.insideUnitCircle * initForce);
    }
    void Update()
    {
        if (hurtTime < hurtPeriod)
        {
            rend.material.SetColor(
                "_EmissionColor",
                Color.Lerp(Color.white, Color.black, hurtTime / hurtPeriod));
        }
        hurtTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            hp -= 1;
            if (hp == 0)
            {
                Destroy(gameObject);
                UI.instance.UpdateScore(1000);
                if (pos1 != null)
                {
                    Instantiate(tinyAsteroid, pos1.position, transform.rotation);
                }
                if (pos2 != null)
                {
                    Instantiate(tinyAsteroid, pos2.position, transform.rotation);
                }
                if (pos3 != null)
                {
                    Instantiate(tinyAsteroid, pos3.position, transform.rotation);
                }
            }
            else
            {
                UI.instance.UpdateScore(10);
                rend.material.SetColor("_EmissionColor", Color.white);
                hurtTime = 0f;
                rb.AddForce(other.gameObject.transform.up * bulletPushForce);
            }
        }
    }
}
