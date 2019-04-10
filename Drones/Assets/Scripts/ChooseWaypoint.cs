using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWaypoint : MonoBehaviour
{
    //Variables
    private GameObject[] waypoints = new GameObject[2];
    private string[] names = new string[2];
    private int tabCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Make an array of waypoints
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
        //Switch between waypoints
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            tabCount = tabCount + 1;
        }

        //Enables or disables certain components based on which waypoint is selected
        for (int i = 0; i <= 1; i++)
        {
            if(tabCount%2 == i)
            {
                //Waypoint can move
                waypoints[i].GetComponent<WaypointMove>().enabled = true;

                //Waypoint can undo lines and draw lines to new points
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
