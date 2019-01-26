using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDistractionObject : MonoBehaviour
{
	[SerializeField]
	private GameObject stainObject, bottleObject;
    private Rigidbody rb;

	private float time = 0.7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Floor")
		{
			StartCoroutine(RemoveFromGame());
		}
	}

	private IEnumerator RemoveFromGame()
	{
		float localTime = 0f;
		transform.up = Vector3.up;
        rb.isKinematic = true;
        GetComponent<Collider>().isTrigger = true;
        stainObject.SetActive(true);
        bottleObject.SetActive(false);
		stainObject.transform.localScale = new Vector3(0.00001f, 0.00001f, 0.00001f);
		while (true)
		{
			yield return null;

			stainObject.transform.localScale = Vector3.Lerp(new Vector3(0.00001f, 0.00001f, 0.00001f), Vector3.one, localTime / time);
			localTime += Time.deltaTime;
			if (localTime > time)
				break;
		}


		LevelManager.instance.RegisterBottle(transform);
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            StartCoroutine(FadePuddle());
        }
    }

    private IEnumerator FadePuddle()
    {
        float localTime = 0f;
        while (true)
        {
            yield return null;
            stainObject.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.00001f, 0.00001f, 0.00001f), localTime / time);
            localTime += Time.deltaTime;
            if (localTime > time)
                break;
        }
        Destroy(gameObject);
    }
}
