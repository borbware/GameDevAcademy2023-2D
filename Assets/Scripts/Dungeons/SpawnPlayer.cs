using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Start()
    {
        if (DungeonMaster.instance.spawnLocationName != "")
        {
            GameObject spawnLocation = GameObject.Find(DungeonMaster.instance.spawnLocationName);
            transform.position = spawnLocation.transform.position;
        }
    }

    void Update()
    {
        
    }
}
