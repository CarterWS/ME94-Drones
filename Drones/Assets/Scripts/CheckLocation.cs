using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLocation : MonoBehaviour
{
    //Variables
    private float[] locations;
    float x;
    float y = 0.75f;
    float z = -1;
    private Vector3 coord;
    public GameObject drone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CURRENTLY NOT USED
        //Could check locations based on marvelmind data
        locations = GameObject.Find("Sorter").GetComponent<Sorter>().locations;
        if (locations[0] != 0.0f)
        {
            coord = new Vector3(locations[1], locations[2], locations[3]);
            drone.transform.position = coord;
        }
    }
}
