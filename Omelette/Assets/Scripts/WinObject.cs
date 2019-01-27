using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    [SerializeField]
    private string audioClipName;

    public void OnPickUp()
    {
        playerManager.hasWin = true;
        LevelManager.instance.announcementManager.PlayAudio(audioClipName);
    }
}
