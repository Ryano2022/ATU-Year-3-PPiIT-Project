using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Points awarded to the player. Starts with 0.
    public static int points = 0;
    public static GameObject endPanel;
    public static GameObject pointCounter;
    public static GameObject timer;
    public static GameObject basket;
    public static GameObject endPointCounter;


    void Start() {
        basket = GameObject.Find("Basket");
        timer = GameObject.Find("Timer");
        pointCounter = GameObject.Find("Point Counter");
        endPanel = GameObject.Find("End Panel");

        RestartLevel();
    }

    // Ending the level.
    public static void EndLevel() {
        Debug.Log("Ending the level. ");

        // Destroy all the collectables.
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Point");
        foreach(GameObject collectable in collectables) {
            Destroy(collectable);
            Debug.Log("Destroyed: " + collectable.name);
        }

        // Hide the basket and timer.
        basket.GetComponent<Renderer>().enabled = false;
        timer.SetActive(false);

        // Move the point counter to the end panel.
        pointCounter.transform.SetParent(endPanel.transform, false);
        pointCounter.transform.localPosition = new Vector3(-80, 180, 0);

        // Show the end panel.
        endPanel.SetActive(true);

        // Save the high score.
        HighScoreCounter.SaveHighScore();
    }

    // Restarting the level.
    public static void RestartLevel() {
        Debug.Log("Restarting the level. ");
        // Hide the end panel.
        endPanel.SetActive(false);

        // Reset the timer and points.
        Timer.levelTime = 10.0f;
        points = 0;
        UpdatePoints();

        // Move the point counter back to the canvas.
        pointCounter.transform.SetParent(GameObject.Find("Canvas").transform, false);
        pointCounter.transform.localPosition = new Vector3(-160, 400, 0);

        // Show them.
        basket.GetComponent<Renderer>().enabled = true;
        timer.SetActive(true);
        pointCounter.SetActive(true);
    }

    public static void UpdatePoints() {
        // Updating the point counter.
        pointCounter.GetComponent<TMPro.TextMeshProUGUI>().text = "Points: " + points;
    }
}
