using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionScript : MonoBehaviour
{

    public string nextSceneName; // Name of the scene to transition to
    public float transitionDelay = 1f; // Delay before transitioning to the next scene

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", transitionDelay); // Invoke LoadNextScene after transitionDelay
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}


    
