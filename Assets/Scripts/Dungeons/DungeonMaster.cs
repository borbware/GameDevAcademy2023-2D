using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public enum KeyTypeEnum {
        Blue,
        Yellow,
        Green
    }
    public int blueKeys = 0;
    public int greenKeys = 0;
    public int yellowKeys = 0;

    public string spawnLocationName;
    public static DungeonMaster instance; 

    public bool PlayerHasKey(KeyTypeEnum keyType)
    {
        if (keyType == KeyTypeEnum.Blue)
        {
            return blueKeys > 0;
        }
        else if (keyType == KeyTypeEnum.Yellow)
        {
            return yellowKeys > 0;
        }
        else if (keyType == KeyTypeEnum.Green)
        {
            return greenKeys > 0;
        }
        return false;
    }
    public void AddKeys(KeyTypeEnum keyType, int amount)
    {
        if (keyType == KeyTypeEnum.Blue)
        {
            blueKeys += amount;
        }
        else if (keyType == KeyTypeEnum.Yellow)
        {
            yellowKeys += amount;
        }
        else if (keyType == KeyTypeEnum.Green)
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
