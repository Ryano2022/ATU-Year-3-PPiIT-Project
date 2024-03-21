using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class HighScoreCounter : MonoBehaviour
{
    public static string filePath;
    public static int highScore = 0;
    public static GameObject highScoreCounter;

    // Start is called before the first frame update. 
    void Start() {
        // Set the file path.
        filePath = Application.persistentDataPath + "/highscore.txt";

        // Find the high score counter.
        highScoreCounter = GameObject.Find("High Score Text").GetComponent<TMPro.TextMeshProUGUI>().gameObject;

        // Load the high score.
        LoadHighScore();
    }

    public static void UpdateHighScore() {
        // Update the high score if the current score is higher.
        if(GameManager.points > highScore) {
            highScore = GameManager.points;
            if(SceneManager.GetActiveScene().buildIndex == 0) {
                highScoreCounter.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + highScore;
            }
            Debug.Log("New high score: " + highScore);
        }
    }

    // Reset the high score.
    public static void ResetHighScore() {
        highScore = 0;
        highScoreCounter.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + highScore;
        SaveHighScore();
        Debug.Log("Reset high score: " + highScore);
    }

    public static void SaveHighScore() {
        // Save the high score to a file.
        File.WriteAllText(filePath, highScore.ToString());
        Debug.Log("Saved high score: " + highScore);
    }

    public static void LoadHighScore() {
        // Load the high score from a file.
        if(File.Exists(filePath)) {
            highScore = int.Parse(File.ReadAllText(filePath));
            Debug.Log("Loaded high score: " + highScore);
            highScoreCounter.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + highScore;
        }
    }
}
