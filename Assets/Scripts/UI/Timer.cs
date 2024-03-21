using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float levelTime = 30.0f;
    // Get the text component of the game object.
    private TMPro.TextMeshProUGUI timerText;

    // Start is called before the first frame update.
    void Start() {
        // Get the text component of the game object.
        timerText = GetComponent<TMPro.TextMeshProUGUI>();
        
        // Set the text to the current time.
        timerText.text = "Time: " + levelTime.ToString("F0");
    }

    // Update is called once per frame.
    void Update() {
        timerText = GetComponent<TMPro.TextMeshProUGUI>();

        // Update the time.
        if (levelTime > 0) {
            levelTime -= Time.deltaTime;
            timerText.text = "Time: " + levelTime.ToString("F0");
        }
        // If the time is less than or equal to 0, end the level.
        else if(levelTime <= 0) {
            GameManager.EndLevel();
        }
    }
}
