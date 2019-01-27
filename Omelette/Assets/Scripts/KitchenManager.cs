using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] narrations;
    [SerializeField]
    private AudioSource audioSource;
    private GlobalGameManager GGManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
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
