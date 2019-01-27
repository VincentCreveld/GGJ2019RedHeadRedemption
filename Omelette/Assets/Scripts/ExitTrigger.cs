using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    private GlobalGameManager GGManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerManager.hasWin)
                GGManager.FinishLevel();
        }
    }
}
