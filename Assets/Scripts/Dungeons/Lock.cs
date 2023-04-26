using UnityEngine;
using static DungeonMaster;

public class Lock : MonoBehaviour
{
    public KeyType keyType;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && DungeonMaster.instance.PlayerHasKey(keyType))
        {
            Destroy(gameObject);
            DungeonMaster.instance.AddKeys(keyType, -1);
        }
    }

}
