using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public float halfScreenWidth = 11.2f;
    public float halfScreenHeight = 6.3f;

    [SerializeField] GameObject Asteroid;
    void Start()
    {
        SpawnAsteroids(3);
    }
    void SpawnAsteroids(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector2 position;
            do
            {
                position = new Vector2(
                    Random.Range(-halfScreenWidth, halfScreenWidth),
                    Random.Range(-halfScreenHeight, halfScreenHeight)
                );
            }
            while (PositionHasOther(position, 5));

            Instantiate(Asteroid, position, Quaternion.identity);
        }
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
