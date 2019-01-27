using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayLineScaler : MonoBehaviour
{
	[SerializeField]
	private Transform lineToScale;

	[SerializeField]
	private float rayLength;

	[SerializeField]
	private Transform cursor;
	private bool isCursorValid = false;

	[SerializeField]
	private LayerMask layerMask;

	private void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength, layerMask))
		{
			cursor.position = hit.point;
			float scale = 0f;

			scale = Vector3.Distance(lineToScale.position, hit.point);

			if (scale > 0)
			{
				isCursorValid = true;
				cursor.position = hit.point;
				lineToScale.LookAt(hit.point);
				lineToScale.transform.localScale = new Vector3(lineToScale.transform.localScale.x, lineToScale.transform.localScale.y, scale);
			}
		}
		else
		{
			isCursorValid = false;
			//Fallback in case no hit is found.
			lineToScale.LookAt(lineToScale.position + lineToScale.forward);
			lineToScale.transform.localScale = new Vector3(lineToScale.transform.localScale.x, lineToScale.transform.localScale.y, rayLength);
		}
	}

	public bool GetIsCursorValid()
	{
		return isCursorValid;
	}

	public Vector3 GetCursorPos()
	{
		return cursor.position;
	}
}
