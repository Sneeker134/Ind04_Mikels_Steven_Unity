using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{

    private Transform[] waypoints;
    private int currentWaypoint = 0;
    private float rotationSpeed = 4f;

    public GameObject waypointContainer;
    public float speed = 500f;
    public float neighborhood = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();
        waypoints = new Transform[potentialWaypoints.Length - 1];

        for(int i = 0, j = 0; i < potentialWaypoints.Length; i++)
        {
            if(potentialWaypoints[i] != waypointContainer.transform)
            {
                waypoints[j++] = potentialWaypoints[i];
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movementVector = NavigateTowardWaypoint();
        GetComponent<Rigidbody>().velocity = movementVector.normalized * speed * Time.fixedDeltaTime;
    }

    Vector3 NavigateTowardWaypoint()
    {
        Vector3 movementVector = waypoints[currentWaypoint].position - transform.position;

        if(movementVector.magnitude <= neighborhood)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        return movementVector;
    }
}
