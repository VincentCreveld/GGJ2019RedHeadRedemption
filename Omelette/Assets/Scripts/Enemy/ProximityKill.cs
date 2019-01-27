using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Enemy>().KillPlayer();
        }
    }
}
