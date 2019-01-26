using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class Awareness : MonoBehaviour
{
    Enemy enemy;
    Patrol patrol;
    NavMeshAgent agent;

    [SerializeField]
    private bool isEmployee;

    [SerializeField]
    private float timeToClean;
    [SerializeField]
    private float lookAtTime;

    private Vector3 ogRotation;
    private Vector3 ogPosition;

    private void Start()
    {
        ogRotation = transform.rotation.eulerAngles;
        ogPosition = transform.position;
        patrol = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToClean(Vector3 posToMove)
    {
        if (isEmployee)
        {
            StartCoroutine(CleanUp(posToMove));
        }
    }

    public void LookAtNoise(Vector3 posOfNoise)
    {
        StartCoroutine(LookAt(posOfNoise));
    }

    private IEnumerator LookAt(Vector3 posOfNoise)
    {
        transform.LookAt(posOfNoise);
        yield return new WaitForSeconds(lookAtTime);
        transform.LookAt(ogRotation);
    }

    private IEnumerator CleanUp(Vector3 posToMove)
    {
        if (patrol) patrol.isStopped = true;
        agent.SetDestination(posToMove);

        while (agent.remainingDistance < 0.1f)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timeToClean);

        if (patrol) patrol.isStopped = false;
        else agent.SetDestination(ogPosition);
    }

    public bool GetIsEmployee()
    {
        return isEmployee;
    }
}