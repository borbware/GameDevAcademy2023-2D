using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float halfScreenWidth = 11.2f;
    public float halfScreenHeight = 6.3f;
    public List<GameObject> asteroids = new List<GameObject>();
    [SerializeField] int asteroidsToSpawn = 3;
    [SerializeField] AudioMixerSnapshot volumeOn;
    [SerializeField] AudioMixerSnapshot volumeOff;

    [SerializeField] GameObject Asteroid;
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        SpawnAsteroids();
    }
    void CheckPositionAndCreateAsteroid()
    {
        for (int tries = 10; tries > 0; tries--)
        {
            Vector2 position = new Vector2(
                Random.Range(-halfScreenWidth, halfScreenWidth),
                Random.Range(-halfScreenHeight, halfScreenHeight)
            );
            if (!PositionHasOther(position, 5))
            {
                Instantiate(Asteroid, position, Quaternion.identity);
                break;
            }
        }
    }
    public void SpawnAsteroids()
    {
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            CheckPositionAndCreateAsteroid();
        }
        asteroidsToSpawn++;
    }
    bool PositionHasOther(Vector2 pos, float radius)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        Collider2D[] results = new Collider2D[5];
        int collisions = Physics2D.OverlapCircle(pos, radius, contactFilter, results);
        return collisions > 0;
    }
    bool PositionHasOther3D(Vector3 pos, float radius) // for reference
    {
        return Physics.CheckSphere(pos, radius);
    }
}
