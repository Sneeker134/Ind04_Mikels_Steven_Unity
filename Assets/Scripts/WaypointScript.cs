using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public GameObject next;
    public bool isStart = false;

    void Awake()
    {

        if (!next)
        {
            print("This waypoint isn't connected, bro.");
        }
    }

    void OnDrawGizmos()
    {

        Gizmos.color = new Color(1, 0, 0, .3f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (next)
        {
            Gizmos.color = new Color(0, 1, 0, 1f);
            Gizmos.DrawLine(transform.position, next.transform.position);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
