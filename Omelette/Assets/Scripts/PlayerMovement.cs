using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent playerModel;
	[SerializeField]
	private Transform camPosInPlayer;

	[SerializeField]
	private Transform camObject;

	[SerializeField]
	private RayLineScaler raycaster;


	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			raycaster.gameObject.SetActive(true);
			playerModel.isStopped = false;
			playerModel.SetDestination(raycaster.GetCursorPos());
		}
		else
		{
			raycaster.gameObject.SetActive(false);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			TeleportCamera();
			playerModel.isStopped = true;
		}
	}

	// Should be a slow teleport with fade out and fade in.
	private void TeleportCamera()
	{
		camObject.position = camPosInPlayer.position;
	}
}
