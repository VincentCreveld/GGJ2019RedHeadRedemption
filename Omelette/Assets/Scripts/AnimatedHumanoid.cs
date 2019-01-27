using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatedHumanoid : MonoBehaviour
{
	[SerializeField]
	private PlayerManager playerManager;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private NavMeshAgent playerAgent;

	private float sanity;

	private void Awake()
	{
		if (playerManager == null)
			this.enabled = false;
	}

	private void Update()
	{
		SetSanity();
		SetIsWalking();
	}

	private void SetSanity()
	{
		playerManager.GetCurrentSanityOnScale01();
		anim.SetFloat("Sanity", sanity);
	}

	private void SetIsWalking()
	{
		anim.SetBool("IsWalking", playerAgent.isStopped);
	}

}
