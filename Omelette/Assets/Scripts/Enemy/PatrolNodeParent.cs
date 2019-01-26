using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNodeParent : MonoBehaviour
{
    public PatrolNode[] points;
    // Start is called before the first frame update
    private void Start()
    {
        points = new PatrolNode[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i).GetComponent<PatrolNode>();
        }
    }
}
