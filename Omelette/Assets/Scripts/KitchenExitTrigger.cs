using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenExitTrigger : MonoBehaviour
{
    private GlobalGameManager GGManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GGManager.GoToNextLevel();
    }
}
