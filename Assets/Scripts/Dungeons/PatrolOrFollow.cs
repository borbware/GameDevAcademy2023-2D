using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PatrolOrFollow : MonoBehaviour
{
    GameObject Player;
    AIDestinationSetter aiset;
    AIPath aipath;
    [SerializeField] List<Transform> patrolPoints = new List<Transform>();
    [SerializeField] int currentTarget;
    void Start()
    {

        aiset = GetComponent<AIDestinationSetter>();
        aipath = GetComponent<AIPath>();
        Player = GameObject.FindGameObjectWithTag("Player");

        // move patrolpoints under enemypatrolpoints so they won't move as enemy moves
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
        if (Cameraf.IsOnScreen(transform))
        {
            aiset.target = Player.transform;
        }
        else
        {
            if (aiset.target == Player.transform)
            {
                SetCurrentTarget(currentTarget);
            }

            Vector3 distance = aiset.target.transform.position - transform.position;

            if (distance.magnitude < aipath.endReachedDistance)
            {
                SetCurrentTarget(currentTarget + 1);
            }
        }
    }
}
