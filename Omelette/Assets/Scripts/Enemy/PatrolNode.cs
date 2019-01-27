using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolNode : MonoBehaviour
{
    public bool isCleared;
    private float debugSphereSize;
    [SerializeField]
    public bool isLookNode;

    // Start is called before the first frame update
    void Start()
    {
        isCleared = false;
    }

    public void Enter(NavMeshAgent agent)
    {
        isCleared = false;
        if (isLookNode)
        {
            LookBehaviour(agent);
        }
        else
        {
            isCleared = true;
        }
    }

    private void LookBehaviour(NavMeshAgent agent)
    {
        float r = UnityEngine.Random.Range(0, 10);
        if (r <= 5) Debug.Log("LookLeft");
        else Debug.Log("LookRight");
        StartCoroutine(StopPatrol(agent));
        isCleared = true;
    }

    private IEnumerator StopPatrol(NavMeshAgent agent)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        agent.isStopped = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
