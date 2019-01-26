using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    public void OnPickUp()
    {
        playerManager.hasWin = true;
        gameObject.SetActive(false);
    }
}
