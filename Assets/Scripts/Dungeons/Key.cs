using UnityEngine;
using static DungeonMaster;

public class Key : MonoBehaviour
{
    public KeyType keyType;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DungeonMaster.instance.AddKeys(keyType, 1);
        }
    }
}
