using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private List<AudioNameKeyPair> audioList;
	private Dictionary<string, AudioClip> audioLibrary;

	private AudioClip currentClip;
	private Queue<AudioClip> audioQueue;

	[SerializeField]
	private AudioSource audioSource;
	private bool isAudioPlaying;

	private void Awake()
	{
		audioLibrary = new Dictionary<string, AudioClip>();
		foreach (var item in audioList)
		{
			audioLibrary.Add(item.name, item.clip);
		}

		audioQueue = new Queue<AudioClip>();
	}
	private void Start()
	{
		StartCoroutine(AudioCycle());
	}

	private IEnumerator AudioCycle()
	{
		while (true)
		{
			while (audioQueue.Count <= 0 || isAudioPlaying)
				yield return null;

			currentClip = audioQueue.Dequeue();
			float delay = currentClip.length;
			audioSource.clip = currentClip;
			audioSource.Play();
			isAudioPlaying = true;
			yield return new WaitForSeconds(delay);
			Debug.Log("here");
			audioSource.Stop();
			audioSource.clip = null;
			isAudioPlaying = false;
		}
	}
	
	public void PlayAudio(string audioClip)
	{
		if (audioLibrary.ContainsKey(audioClip))
			audioQueue.Enqueue(audioLibrary[audioClip]);
	}

	[ContextMenu("yeet")]
	public void PlaySound()
	{
		PlayAudio("yeet");
	}

	[ContextMenu("bruh")]
	public void PlaySound2()
	{
		PlayAudio("bruh");
	}

	[ContextMenu("alarm")]
	public void PlaySound3()
	{
		PlayAudio("alarm");
	}
}

[Serializable]
public class AudioNameKeyPair
{
	public string name;
	public AudioClip clip;
}
