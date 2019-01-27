using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenExitTrigger : MonoBehaviour
{
    private GlobalGameManager GGManager;
    [SerializeField]
    private KitchenManager kitchenManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(GGManager.narrationClipsPlayed[kitchenManager.previouslevel])
            GGManager.GoToNextLevel();
        }
    }
}
