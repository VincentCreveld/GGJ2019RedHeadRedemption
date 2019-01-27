using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] narrations;
    [SerializeField]
    private AudioSource audioSource;
    public int previouslevel;
    private GlobalGameManager GGManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
        if (!GGManager.firstNarrationPlayed)
        {
            PlayNarration(0);
            GGManager.firstNarrationPlayed = true;
        }
    }

    public void PlayNarration(int index)
    {
        if (!GGManager.narrationClipsPlayed[index])
        {
            audioSource.clip = narrations[index];
            audioSource.Play();
            GGManager.narrationClipsPlayed[index] = true;
        }
    }
}
