using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : MonoBehaviour
{

    HelloClient client;
    public float[] locations;
    public float[] xbox;
    string m;
    private int i = 0;
    private int len = 17;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        client = GetComponent<HelloClient>();
        m = client._helloRequester.sentMessage;
        if (m != "null")
        {
            if(i%len < 5)
            {
                locations[i % len] = float.Parse(m);
            }
            if(i%len >= 5)
            {
                xbox[(i - 5) % len] = float.Parse(m);
            }
            i += 1;
        }
    }
}
