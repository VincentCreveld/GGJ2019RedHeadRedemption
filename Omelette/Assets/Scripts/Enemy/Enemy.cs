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
            if (angle <= visionAngle)
            {
                if (CheckCollision())
                    playerManager.DecreaseSanity(maxSanityLoss / 60f);
            }
        }
    }

    private bool CheckCollision()
    {
        RaycastHit hit;
        Vector3 ToShootFrom = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        Debug.Log(player.name);
        Debug.DrawLine(ToShootFrom, player.transform.position);
        if (Physics.Raycast(ToShootFrom, player.transform.position, out hit, visionDistance))
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionDistance);
    }
}
