using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public void UpdatePoints(int newPoints) {
        // Update the UI.
        GetComponent<TMPro.TextMeshProUGUI>().text = "Points: " + GameManager.points.ToString();
    }
}
