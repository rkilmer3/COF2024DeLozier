using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDirector : MonoBehaviour
{
    public void directToLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
