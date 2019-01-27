using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNarratorTrigger : MonoBehaviour
{
    [SerializeField]
    private KitchenManager kitchenManager;
    private GlobalGameManager GGManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !GGManager.firstNarrationPlayed)
        {
            kitchenManager.PlayNarration(0);
        }
    }
}
