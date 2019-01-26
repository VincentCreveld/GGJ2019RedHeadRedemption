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
        debugSphereSize = 0.25f;
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
        float r = UnityEngine.Random.Range(0, 1);
        if (r <= 0.5f) Debug.Log("LookLeft");
        else Debug.Log("LookRight");
        StartCoroutine(ChangeDebugValue(agent));
        isCleared = true;
    }

    private IEnumerator ChangeDebugValue(NavMeshAgent agent)
    {
        debugSphereSize = 1f;
        agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        agent.isStopped = false;
        debugSphereSize = 0.25f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, debugSphereSize);
    }
}
