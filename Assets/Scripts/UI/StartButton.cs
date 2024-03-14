using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadGame()
    {
        // Loads level 01 (1 is the index of the level in the build settings).
        SceneManager.LoadScene(1);
    }
}
