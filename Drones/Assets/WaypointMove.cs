using UnityEngine;
using UnityEngine.AI;

public class WaypointMove : MonoBehaviour
{
    //Initialize variables
    public Camera cam;
    public NavMeshAgent agent;
    public Rigidbody rb;
    public string mode;
    private float[] controls;
    private float x,y,z;
    public float speed;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
        //If the mode is mouse, move the waypoint to where the user clicks
        if(mode.ToLower() == "mouse")
        {
            rb.velocity = new Vector3(0, 0, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    rb.transform.position = hit.point;
                }
            }
        }

        //If the mode is controller, move at a certain speed based on joystick inputs
        if(mode.ToLower() == "controller")
        {
            agent.ResetPath();
            controls = GameObject.Find("Sorter").GetComponent<Sorter>().xbox;
            x = controls[8] * speed;
            y = controls[9] * speed;
            z = controls[10] * speed;
            rb.velocity = new Vector3(x,y,z);
        }
    }
}
