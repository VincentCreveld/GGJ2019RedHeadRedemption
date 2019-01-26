using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject objToSpawn;
	[SerializeField]
	private GameObject objInstance;
	[SerializeField]
	private float spawnDelayAfterNulled;

    // Update is called once per frame
    private void FixedUpdate()
    {
		if (objInstance == null)
			StartCoroutine(SpawnObj());
	}

	private IEnumerator SpawnObj()
	{
		objInstance = new GameObject();
		yield return new WaitForSeconds(spawnDelayAfterNulled);
		objInstance = Instantiate(objToSpawn, transform.position, objToSpawn.transform.rotation);
	}
}
