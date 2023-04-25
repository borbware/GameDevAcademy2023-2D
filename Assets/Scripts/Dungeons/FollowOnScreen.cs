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
    
    bool OnScreen()
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
        Vector3 difference = Camera.main.transform.position - transform.position;
        return (
            Mathf.Abs(difference.x) < cameraHalfWidth 
            && Mathf.Abs(difference.y) < cameraHalfHeight
        );
    }
    void Update()
    {
        if (OnScreen())
        {
            aiset.target = Player.transform;
        } else if (returnToSpawnPoint) {
            aiset.target = Spawnpoint.transform;
        }
    }
}
