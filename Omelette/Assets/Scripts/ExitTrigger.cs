using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerManager.hasWin)
        {
            Debug.Log("YOU HAVE WON");
        }
    }
}
