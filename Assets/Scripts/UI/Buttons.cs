using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadMainMenu() {
        // Loads the main menu.
        SceneManager.LoadScene(0);
        Debug.Log("Loaded scene: " + SceneManager.GetSceneByBuildIndex(0).name);
    }

    public void LoadGame() {
        // Loads the main level.
        if(SceneManager.GetActiveScene().buildIndex == 1) {
            GameManager.RestartLevel();
        }
        else {
            SceneManager.LoadScene(1);
            Debug.Log("Loaded scene: " + SceneManager.GetSceneByBuildIndex(1).name);
        }
    }
}
