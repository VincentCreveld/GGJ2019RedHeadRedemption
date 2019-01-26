using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;

	[SerializeField]
	private List<NavMeshAgent> enemies;

	[SerializeField]
	private AudioManager announcementManager;

	private string clipToPlay = "yeet";

	public Transform bottlepos;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
			Debug.LogError("Too many LevelManagers in scene. Disabling LevelManager on " + name);
			this.enabled = false;
		}
	}

	public void RegisterBottle(Vector3 pos)
	{
		StartCoroutine(SendAgentToPos(2f, GetClosestAgent(pos), pos));
	}

	private IEnumerator SendAgentToPos(float delay, NavMeshAgent agent, Vector3 pos)
	{
		yield return new WaitForSeconds(delay);
		agent.GetComponent<Awareness>().MoveToClean(pos);
		announcementManager.PlayAudio(clipToPlay);
	}

	private NavMeshAgent GetClosestAgent(Vector3 pos)
	{
		NavMeshAgent closestEnemy = null;
		float closestDist = 100f;
		foreach (var enemy in enemies)
		{
			float dist = Vector3.Distance(enemy.transform.position, pos);
			if (dist < closestDist)
			{
				closestEnemy = enemy;
				closestDist = dist;
			}
		}

		return closestEnemy;
	}

	[ContextMenu("bottle")]
	public void MovetoBottle()
	{
		RegisterBottle(bottlepos.position);
	}
}
