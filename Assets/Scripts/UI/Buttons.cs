using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadMainMenu() {
        // Loads the main menu.
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(0);
        Debug.Log("Loaded scene: " + SceneManager.GetSceneByBuildIndex(0).name);
    }

    public void LoadGame() {
        // Loads the main level.
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(1);
        GameManager.RestartLevel();
        Debug.Log("Loaded scene: " + SceneManager.GetSceneByBuildIndex(1).name);
    }
}
