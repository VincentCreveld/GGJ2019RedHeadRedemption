using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistractionObject : MonoBehaviour
{
	[SerializeField]
	private float detectionRange;
	[SerializeField]
	private LayerMask layerMask;

	private bool isPopped = false;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Level" && !isPopped)
		{
			isPopped = true;
			SendMessageToNearbyAgent();
		}
	}

	private void SendMessageToNearbyAgent()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, layerMask);
		List<Awareness> awarenessScripts = new List<Awareness>();
		foreach (var item in colliders)
		{
			if (item.GetComponent<Awareness>() != null)
			{
				awarenessScripts.Add(item.GetComponent<Awareness>());
			}
		}
		if (awarenessScripts.Count <= 0)
			return;

		GetClosestAgent(awarenessScripts).LookAtNoise(transform.position);
	}

	private Awareness GetClosestAgent(List<Awareness> list)
	{
		Awareness closestAwareness = null;
		float closestDist = detectionRange + 1f;
		foreach (var awareness in list)
		{
			float dist = Vector3.Distance(awareness.transform.position, transform.position);
			if (dist < closestDist)
			{
				closestAwareness = awareness;
				closestDist = dist;
			}
		}

		return closestAwareness;
	}

	public void ResetPickupable()
	{
		isPopped = false;
	}
}
