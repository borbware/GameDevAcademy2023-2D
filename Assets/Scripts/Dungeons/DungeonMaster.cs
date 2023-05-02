using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public enum KeyType {
        Blue,
        Yellow,
        Green
    }
    public int blueKeys = 0;
    public int greenKeys = 0;
    public int yellowKeys = 0;

    public string spawnLocationName;
    public static DungeonMaster instance;

    public bool PlayerHasKey(KeyType keyType)
    {
        if (keyType == KeyType.Blue)
        {
            return blueKeys > 0;
        }
        else if (keyType == KeyType.Yellow)
        {
            return yellowKeys > 0;
        }
        else if (keyType == KeyType.Green)
        {
            return greenKeys > 0;
        }
        return false;
    }

    public void AddKeys(KeyType keyType, int amount)
    {
        if (keyType == KeyType.Blue)
        {
            blueKeys += amount;
        }
        else if (keyType == KeyType.Yellow)
        {
            yellowKeys += amount;
        }
        else if (keyType == KeyType.Green)
        {
            greenKeys += amount;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
