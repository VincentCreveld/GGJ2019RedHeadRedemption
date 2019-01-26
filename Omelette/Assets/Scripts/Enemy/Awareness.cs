using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class Awareness : MonoBehaviour
{
    private Enemy enemy;
    private Patrol patrol;
    private NavMeshAgent agent;

    [SerializeField]
    private bool isEmployee;

    [SerializeField]
    private float timeToClean;
    [SerializeField]
    private float lookAtTime;

    private Vector3 ogRotation;
    private Vector3 ogPosition;

    [SerializeField]
    private Transform graphics;
    private void Start()
    {
        ogRotation = transform.rotation.eulerAngles;
        ogPosition = transform.position;
        patrol = GetComponent<Patrol>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MoveToClean(new Vector3(-7.24f, 0, 2));
        //}
    }

    public void MoveToClean(Transform posToMove)
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

    private IEnumerator CleanUp(Transform posToMove)
    {
        if (patrol) patrol.isStopped = true;
        agent.SetDestination(posToMove.position);

        //while (agent.remainingDistance < 0.1f)
        while (Vector3.Distance(graphics.transform.position, posToMove.position) < 0.1f)
        {
            yield return null;
        }
        yield return new WaitForSeconds(timeToClean);

        if (patrol) patrol.isStopped = false;
        else agent.SetDestination(ogPosition);
    }
}