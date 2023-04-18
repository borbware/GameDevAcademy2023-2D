using UnityEngine;

public class Loops : MonoBehaviour
{
    [SerializeField] GameObject solttu;

    void Awake()
    {
        int count = 0;
        do
        {
            Debug.Log(count);
            count--;
        } while (count > 2);
        // count = -1


        int j = 0;
        while ( j <= 10 )
        {
            Debug.Log(j);
            j++;
        }

        for (int i = 0; i <= 10; i++)
        {
            Debug.Log(i);
        }

        for (int i = 1; i < 10; i += 2)
        {
            Debug.Log(i);
        }

        for (int i = 0; i > -10; i-- )
        {
            Debug.Log(i);
        }
        Debug.Log("skip parilliset");
        for (int i = 1; i < 10; i += 1)
        {
            if (i % 2 == 0) // "if parillinen"
            {
                continue;
            }
            Debug.Log(i);
        }

        Debug.Log("x and y loop");
        for (int x = 0; x < 10; x += 1)
        {
            for (int y = 0; y < 2; y += 1)
            {
                Debug.Log($"x: {x}, y: {y}");
                Instantiate(solttu, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
