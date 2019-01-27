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
	[SerializeField]
	private GameObject mask;
	private GameObject maskInstance;
	private GetAnimationHead animHead;

	[SerializeField]
	private Material monsterMat;
	private Material currentMat;
	private Color startingColor;

	private float sanity = 0f;

	private void Start()
	{
		if (awareness == null)
			enabled = false;

		if (awareness.GetIsEmployee())
		{
			animatedComponent = Instantiate(maleEmployee, transform);
		}
		else
		{
			animatedComponent = Instantiate(maleCustomer, transform);
		}

		anim = animatedComponent.GetComponentInChildren<Animator>();
		animatedComponent.transform.localPosition -= (Vector3.up * 0.5f);
		animHead = animatedComponent.GetComponentInChildren<GetAnimationHead>();

		currentMat = animatedComponent.GetComponentInChildren<Renderer>().material;
		startingColor = currentMat.color;

		maskInstance = Instantiate(mask, animHead.head);
		maskInstance.SetActive(false);
	}

	private void Update()
	{
		SetIsWalking();
		SetAnimSanity();

		if (sanity > 0.6f)
			maskInstance.SetActive(true);

		currentMat.color = BlendColors();
	}

	private void SetAnimSanity()
	{
		sanity = playerManager.GetCurrentSanityOnScale01();
		anim.SetFloat("Sanity", sanity);
	}

	private void SetIsWalking()
	{
		bool val = agent.velocity.magnitude > 1.2f;
		anim.SetBool("IsWalking", val);
	}

	private Color BlendColors()
	{
		Color col = new Color();

		col = Color.Lerp(startingColor, monsterMat.color, sanity);

		return col;
	}
}
