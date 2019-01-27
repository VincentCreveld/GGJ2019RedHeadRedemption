using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] narrations;
    [SerializeField]
    private AudioSource audioSource;
    public int previouslevel;
    private GlobalGameManager GGManager;

    private void Start()
    {
        GGManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalGameManager>();
    }

    public void PlayNarration(int index)
    {
        audioSource.clip = narrations[index];
        audioSource.Play();
        GGManager.narrationClipsPlayed[index] = true;
    }
}
