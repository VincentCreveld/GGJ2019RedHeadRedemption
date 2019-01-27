using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR;

public class PlayerMovement : MonoBehaviour
{

	private enum InputType { viveController, mouse }
	[SerializeField]
	private InputType inputType;

	[SerializeField]
	private NavMeshAgent playerModel;
    [SerializeField]
    private Renderer playerRenderer;

	[SerializeField]
	private Transform camPosInPlayer;

	[SerializeField]
	private Transform camObject;

	[SerializeField]
	private RayLineScaler raycaster;

	private bool isInputDown = false, prevIsInputDown = false;

    private void Start()
    {
        playerModel.stoppingDistance = 0f;
    }

    private void Update()
	{
        if (IsSelectionPressed())
		{
            playerRenderer.enabled = true;
			isInputDown = true;
			raycaster.gameObject.SetActive(true);
			playerModel.isStopped = false;
			playerModel.SetDestination(raycaster.GetCursorPos());
		}
		else
		{
			isInputDown = false;
			raycaster.gameObject.SetActive(false);
            playerModel.isStopped = true;
        }

		// Defines onButtonUp timing
		if (prevIsInputDown != isInputDown && isInputDown == false)
		{
			TeleportCamera();
			playerModel.isStopped = true;
            playerRenderer.enabled = false;
            playerModel.transform.position = camObject.position;
		}

		prevIsInputDown = isInputDown;
	}

	// Should be a slow teleport with fade out and fade in.
	private void TeleportCamera()
	{
		camObject.position = camPosInPlayer.position;
	}

	private bool IsSelectionPressed()
	{
		switch (inputType)
		{
			case InputType.mouse:
				return Input.GetKey(KeyCode.Space);
			case InputType.viveController:
				return SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand);
			default:
				return true;
		}
	}
}
