using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject modeChooser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            waypoint1.GetComponent<WaypointMove>().mode = "controller";
            waypoint2.GetComponent<WaypointMove>().mode = "controller";
            modeChooser.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            waypoint1.GetComponent<WaypointMove>().mode = "mouse";
            waypoint2.GetComponent<WaypointMove>().mode = "mouse";
            modeChooser.SetActive(false);
        }
    }
}
