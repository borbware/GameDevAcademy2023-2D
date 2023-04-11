using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
    [SerializeField] GameObject tinyAsteroid;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asdfsa");
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Instantiate(tinyAsteroid, pos1.position, transform.rotation);
            Instantiate(tinyAsteroid, pos2.position, transform.rotation);
            Instantiate(tinyAsteroid, pos3.position, transform.rotation);
        }
    }
}
