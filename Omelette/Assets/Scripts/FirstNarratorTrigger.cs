using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNarratorTrigger : MonoBehaviour
{
    [SerializeField]
    private KitchenManager kitchenManager;
    private GlobalGameManager GGManager;

	private void Start()
	{
		GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GGManager.firstNarrationPlayed)
        {
			GGManager.firstNarrationPlayed = true;

			kitchenManager.PlayNarration(0);
        }
    }
}
