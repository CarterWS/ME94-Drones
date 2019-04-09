using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public GameObject waypoint;
    public NavMeshAgent drone;
    Vector3 target = new Vector3();
    Vector3 startPos = new Vector3(0, 0.75f, -1);

    // Start is called before the first frame update
    void Start()
    {
        drone.Warp(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        target = waypoint.GetComponent<DrawLine>().droneTarget;
        drone.SetDestination(target);
    }
}
