using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModelAssigner : MonoBehaviour
{
	[SerializeField]
	private Awareness awareness;

	private Animator anim;

	[SerializeField]
	private NavMeshAgent agent;
	[SerializeField]
	private PlayerManager playerManager;

	[SerializeField]
	private GameObject maleEmployee, maleCustomer;
	private GameObject animatedComponent;

	private void Start()
	{
		if (awareness == null)
			enabled = false;

		if (awareness.GetIsEmployee())
			animatedComponent = Instantiate(maleEmployee, transform);
		else
			animatedComponent = Instantiate(maleCustomer, transform);

		anim = animatedComponent.GetComponentInChildren<Animator>();
		animatedComponent.transform.localPosition -= (Vector3.up * 0.5f);
	}

	private void Update()
	{
		SetIsWalking();
		SetAnimSanity();
	}

	private void SetAnimSanity()
	{
		anim.SetFloat("Sanity", playerManager.GetCurrentSanityOnScale01());
	}

	private void SetIsWalking()
	{
		bool val = agent.velocity.magnitude > 1.2f;
		anim.SetBool("IsWalking", val);
	}
}
