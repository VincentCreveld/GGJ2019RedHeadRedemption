using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDistractionObject : MonoBehaviour
{
	[SerializeField]
	private GameObject stainObject, bottleObject;

	private float time = 0.7f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Level")
		{
			StartCoroutine(RemoveFromGame(collision.transform.position));
		}
	}

	private IEnumerator RemoveFromGame(Vector3 pos)
	{
		float localTime = 0f;
		transform.up = Vector3.up;
		stainObject.SetActive(true);
		stainObject.transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
		while (true)
		{
			yield return null;

			stainObject.transform.localScale = Vector3.Lerp(new Vector3(0.00001f, 0.00001f, 0.00001f), Vector3.one, localTime / time);
			localTime += Time.deltaTime;
			if (localTime > time)
				break;
		}
		LevelManager.instance.RegisterBottle(pos);
	}
}
