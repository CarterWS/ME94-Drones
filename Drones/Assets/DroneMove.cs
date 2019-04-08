using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public float droneSpeed;
    public GameObject waypoint;
    public NavMeshAgent drone;
    Vector3 target = new Vector3();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = waypoint.GetComponent<DrawLine>().droneTarget;
        drone.SetDestination(target);
    }
}
