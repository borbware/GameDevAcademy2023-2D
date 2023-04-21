using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public string spawnLocationName;
    public static DungeonMaster instance; 

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
