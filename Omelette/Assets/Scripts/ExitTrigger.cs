using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is in Trigger");
            if (playerManager.hasWin)
                Debug.Log("YOU HAVE WON");
        }
    }
}
