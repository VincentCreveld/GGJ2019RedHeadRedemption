// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{
    [SerializeField]
    private PatrolNodeParent patrolParent;
    private PatrolNode[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private int previousdestPoint;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        points = patrolParent.points;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    private void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].transform.position;
        if (destPoint - 1 < 0) previousdestPoint = points.Length - 1;
        else previousdestPoint = destPoint - 1;
        Debug.Log(previousdestPoint);
        points[previousdestPoint].Enter(agent);
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    private void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GotoNextPoint();
        }
    }
}
