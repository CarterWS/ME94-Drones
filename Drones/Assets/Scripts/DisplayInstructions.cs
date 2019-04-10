using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayInstructions : MonoBehaviour
{
    Scene currentScene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (Input.GetKey(KeyCode.H) && sceneName == "Interface")
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKey(KeyCode.Escape) && sceneName == "Instructions")
        {
            SceneManager.LoadScene(1);
        }
    }
}
