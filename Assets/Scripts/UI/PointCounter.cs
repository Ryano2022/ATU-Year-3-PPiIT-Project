using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private int points = 0;

    public void UpdatePoints(int newPoints)
    {
        // Set the new points.
        points = newPoints;
        // Update the UI.
        GetComponent<UnityEngine.UI.Text>().text = "Points: " + points;
    }
}
