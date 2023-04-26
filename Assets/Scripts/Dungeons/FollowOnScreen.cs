using Pathfinding;
using UnityEngine;

public class FollowOnScreen : MonoBehaviour
{
    AIDestinationSetter aiset;
    GameObject Player;
    GameObject Spawnpoint;
    GameObject Spawnpointcontainer;
    [SerializeField] bool returnToSpawnPoint = true;

    void Start()
    {
        aiset = GetComponent<AIDestinationSetter>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Spawnpointcontainer = GameObject.Find("EnemySpawnpoints");
        Spawnpoint = Instantiate(
            new GameObject(),
            transform.position,
            transform.rotation,
            Spawnpointcontainer.transform
        );
    }
    void Update()
    {
        if (Cameraf.IsOnScreen(transform))
        {
            aiset.target = Player.transform;
        } else if (returnToSpawnPoint) {
            aiset.target = Spawnpoint.transform;
        }
    }
}
