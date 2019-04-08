using UnityEngine;

public class HelloClient : MonoBehaviour
{
    public HelloRequester _helloRequester;

    public void Start()
    {
        _helloRequester = new HelloRequester();
        _helloRequester.Start();
    }

    public void OnDestroy()
    {
        _helloRequester.Stop();
    }
}