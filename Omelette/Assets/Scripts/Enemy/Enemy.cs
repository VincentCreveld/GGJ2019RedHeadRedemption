﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float visionDistance, visionAngle;
    [SerializeField]
    private float maxSanityLoss;
    [SerializeField]
    private PlayerManager playerManager;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		GetComponent<HackyFOVCaster>().SetFOV(visionAngle, visionDistance);
    }

    // Update is called once per frame
    void Update()
    {
        Vision();
    }

    /// <summary>
    /// Checks if player is in range and in pov and shoots raycast
    /// </summary>
    private void Vision()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 targetDir = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (distanceToPlayer <= visionDistance)
        {
            if (angle <= visionAngle * 0.5f)
            {
                if (CheckCollision())
                {
                    playerManager.DecreaseSanity(maxSanityLoss / 100f);
                }
            }
        }
    }

    private bool CheckCollision()
    {
        RaycastHit hit;
        Vector3 shootDirection = player.transform.position - transform.position;
        Vector3 ToShootFrom = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        Debug.DrawRay(ToShootFrom, shootDirection);
        if (Physics.Raycast(ToShootFrom, shootDirection, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void KillPlayer()
    {
        playerManager.Lose();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionDistance);
    }

	private void OnDrawGizmosSelected()
	{
		Vector3 target = (transform.forward).normalized * visionDistance;
		target = Quaternion.Euler(0, visionAngle / 2, 0) * target;
		Gizmos.DrawLine(transform.position, (transform.position + target));

		Vector3 target2 = (transform.forward).normalized * visionDistance;
		target2 = Quaternion.Euler(0, -visionAngle / 2, 0) * target2;
		Gizmos.DrawLine(transform.position, (transform.position + target2));
	}
}
