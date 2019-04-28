using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    //Initializing variables that will be used in the code
    public GameObject waypoint;
    public LineRenderer line;
    public GameObject drone;
    public Vector3 droneTarget = new Vector3();
    Vector3[] linePos = new Vector3[20000];
    Vector3 badPos = new Vector3();
    private int numPos = 1;
    private float epsilon = 0.3f;
    private string mode;
    public bool selectedWaypoint;

    //Controller only
    private int[] lastSavedPos = new int[1000];
    private float[] controls;
    private int savePos = 1;
    private bool APress, BPress;


    //Start is called before the first frame update
    void Start()
    {
        //Get the line renderer
        line = GetComponent<LineRenderer>();

        //Last saved position is last time the A button was pressed
        lastSavedPos[0] = 0;

        APress = false;
        BPress = false;
    }


    //Update is called once per frame
    void FixedUpdate()
    {
        //Gets what mode we're using
        mode = waypoint.GetComponent<WaypointMove>().mode;

        //Mouse
        if (mode.ToLower() == "mouse")
        {
            //First position is that of the drone
            linePos[0] = drone.transform.position;

            //Make sure the position isn't the one we just deleted
            if ((waypoint.transform.position - badPos).magnitude > epsilon && selectedWaypoint)
            {
                //If the current position isn't the last one, add it
                if ((linePos[numPos - 1] - waypoint.transform.position).magnitude > epsilon)
                {
                    linePos[numPos] = waypoint.transform.position;
                    numPos = numPos + 1;
                }
            }
            //If we hit escape, delete the last line that was made and make 
            //the position we were at the badPos (deleted position)
            if (Input.GetKeyDown(KeyCode.Escape) && selectedWaypoint)
            {
                if (badPos != waypoint.transform.position)
                {
                    badPos = linePos[numPos - 1];
                }
                linePos[numPos - 1] = linePos[numPos - 2];
                numPos = numPos - 1; 
            }

            //If the drone gets close enough to its next position, remove the
            //next position from the line
            if ((linePos[0] - linePos[1]).magnitude < epsilon)
            {
                for (int i = 1; i < numPos - 1; i++)
                {
                    linePos[i] = linePos[i + 1];
                }
                if (numPos > 2)
                {
                    numPos = numPos - 1;
                }
            }

            //Actually draw the line
            if (numPos > 0)
            {
                line.positionCount = numPos;
                line.SetPositions(linePos);
            }
            //Make it so that the drone knows where to go next
            droneTarget = linePos[1];
        }

        //Controller
        if(mode.ToLower() == "controller")
        {

            //Get the controller inputs
            controls = GameObject.Find("Sorter").GetComponent<Sorter>().xbox;
            linePos[0] = drone.transform.position;

            if (linePos[numPos - 1] != waypoint.transform.position && selectedWaypoint)
            {
                linePos[numPos] = waypoint.transform.position;
                numPos = numPos + 1;
            }

            //If the B button is pressed
            if (controls[1] == 1 && selectedWaypoint)
            {
                BPress = true;
            }

            //If the B button is released delete the positions after the last
            //saved position and set the waypoint back to that saved position
            if (BPress && controls[1] == 0 && selectedWaypoint)
            {
                //For if someone didn't move the waypoint and hit B again,
                //delete the segment before
                if (numPos == lastSavedPos[savePos])
                {
                    savePos = savePos - 1;
                }

                waypoint.transform.position = linePos[lastSavedPos[savePos]];
                for (int i = lastSavedPos[savePos]; i <= numPos; i++)
                {
                    linePos[i] = linePos[lastSavedPos[savePos]];
                }
                numPos = lastSavedPos[savePos];
                BPress = false;
            }

            //If the A button is pressed
            if (controls[0] == 1 && selectedWaypoint)
            {
                APress = true;
            }

            //If the A button is released add that position to the saved position
            if (APress && controls[0] == 1 && selectedWaypoint)
            {
                lastSavedPos[savePos] = numPos;
                savePos = savePos + 1;
                APress = false;
            }

            //If the drone gets close enough to its next position, remove the
            //next position from the line
            if ((linePos[0] - linePos[1]).magnitude < epsilon)
            {
                for (int i = 1; i < numPos - 1; i++)
                {
                    linePos[i] = linePos[i + 1];
                }
                numPos = numPos - 1;
            }

            //Draw the line
            line.positionCount = numPos;
            line.SetPositions(linePos);
        }
    }
}