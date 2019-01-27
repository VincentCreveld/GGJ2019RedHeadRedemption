using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayClipOnHitGround : MonoBehaviour
{
	private bool isPopped = false;

	public AudioClip clipToPlay;
	public AudioSource anim;

	private void Awake()
	{
		anim.clip = clipToPlay;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Floor" && !isPopped)
		{
			isPopped = true;
			anim.Play();
		}
	}
}
