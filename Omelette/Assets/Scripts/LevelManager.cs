using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;

	[SerializeField]
	private List<NavMeshAgent> enemies;

	public AudioManager announcementManager;

	private string clipToPlay = "yeet";

	public Transform bottlePos;

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

	public void RegisterBottle(Transform pos)
	{
		StartCoroutine(SendAgentToPos(2f, GetClosestAgent(pos.position), pos));
	}

	private IEnumerator SendAgentToPos(float delay, NavMeshAgent agent, Transform pos)
	{
		yield return new WaitForSeconds(delay);
		agent.GetComponent<Awareness>().MoveToClean(pos.position);
		announcementManager.PlayAudio(clipToPlay);
	}

	private NavMeshAgent GetClosestAgent(Vector3 pos)
	{
		NavMeshAgent closestEnemy = null;
		float closestDist = 100f;
		foreach (var enemy in enemies)
		{
            if (enemy.GetComponent<Awareness>() != null && !enemy.GetComponent<Awareness>().GetIsEmployee())
                continue;
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
		RegisterBottle(bottlePos);
	}
}
