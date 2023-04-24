using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    AIDestinationSetter aiset;
    AIPath path;
    [SerializeField] List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] int currentTarget;
    void Start()
    {

        aiset = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();

        Transform points = transform.Find("Patrolpoints");
        GameObject newParent = GameObject.Find("EnemyPatrolpoints");
        points.SetParent(newParent.transform);
        
        for (int i = 0; i < points.childCount; i++)
        {
            patrolPoints.Add(points.GetChild(i));
        }
        SetCurrentTarget(0);
    }

    void SetCurrentTarget(int i)
    {
        aiset.target = patrolPoints[i % patrolPoints.Count];
        currentTarget = i % patrolPoints.Count;
    }

    void Update()
    {
        Vector3 distance = aiset.target.transform.position - transform.position;

        if (distance.magnitude < path.endReachedDistance)
        {
            SetCurrentTarget(currentTarget + 1);
        }
    }
}
