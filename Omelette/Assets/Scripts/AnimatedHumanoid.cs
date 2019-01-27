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

	private float sanity = 0f;

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
		sanity = playerManager.GetCurrentSanityOnScale01();
		anim.SetFloat("Sanity", sanity);
	}

	private void SetIsWalking()
	{
        bool val = playerAgent.velocity.magnitude > 1.25f;
		anim.SetBool("IsWalking", val);
	}

}
