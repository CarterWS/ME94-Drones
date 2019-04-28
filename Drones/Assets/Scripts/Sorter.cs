using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    //Variables
    HelloClient client;
    public float[] locations = new float[5];
    public float[] xbox = new float[12];
    string m;
    private int i;
    private int len = 17;
    private float msg;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Sort", 0, 0.0005f);
    }

    void Sort()
    {
        //Makes sure messages are actually being sent, and then sorts the
        //message appropriately to what it corresponds to
        //Very temporary... Only sorts controller inputs (GPS wasn't working)
        client = GetComponent<HelloClient>();
        m = client._helloRequester.sentMessage;
        if (m != "null")
        {
            msg = float.Parse(m);
            if(msg >=155)
            {
                xbox[11] = (msg-160);
            }
            else if(msg >=145)
            {
                xbox[10] = (msg - 150);
            }
            else if (msg >= 135)
            {
                xbox[9] = (msg - 140);
            }
            else if (msg >= 125)
            {
                xbox[8] = (msg - 130);
            }
            else if (msg >= 115)
            {
                xbox[7] = (msg - 120);
            }
            else if (msg >= 105)
            {
                xbox[6] = (msg - 110);
            }
            else if (msg >= 95)
            {
                xbox[5] = (msg - 100);
            }
            else if (msg >= 85)
            {
                xbox[4] = (msg - 90);
            }
            else if (msg >= 75)
            {
                xbox[3] = (msg - 80);
            }
            else if (msg >= 65)
            {
                xbox[2] = (msg - 70);
            }
            else if (msg >= 55)
            {
                xbox[1] = (msg - 60);
            }
            else if (msg >= 45)
            {
                xbox[0] = (msg - 50);
            }
        }
    }
}
