using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWaypoint : MonoBehaviour
{
    private GameObject[] waypoints = new GameObject[2];
    private string[] names = new string[2];
    private int tabCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 1; i++)
        {
            names[i] = "Waypoint " + (i+1);
            waypoints[i] = GameObject.Find(names[i]);
        }
        waypoints[0].GetComponent<LineRenderer>().material.color = Color.green;
        waypoints[1].GetComponent<LineRenderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            tabCount = tabCount + 1;
        }
        for (int i = 0; i <= 1; i++)
        {
            if(tabCount%2 == i)
            {
                waypoints[i].GetComponent<WaypointMove>().enabled = true;
                waypoints[i].GetComponent<DrawLine>().selectedWaypoint = true;
            }
            else
            {
                waypoints[i].GetComponent<WaypointMove>().enabled = false;
                waypoints[i].GetComponent<DrawLine>().selectedWaypoint = false;
            }
        }
    }
}
