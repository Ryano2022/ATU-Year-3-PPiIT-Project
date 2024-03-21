using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f; // Time before the collectable disappears.
    public GameObject pointCounter;
    public GameObject endPointCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking for any collision at all just for testing purposes.
        //Debug.Log("Collision detected with " + collision.gameObject.name);

        // Check for the player.
        if (collision.gameObject.CompareTag("Player")) {
            // Destroy the collectable.
            Destroy(gameObject);

            // Award the player with a point.
            GameManager.points++;
            GameManager.UpdatePoints();
            Debug.Log("Collected: " + gameObject.name + "\nAdded one point.\nCurrent Points: " + GameManager.points);

            // Trying to find the point counter for testing purposes.
            //Debug.Log(GameObject.Find("Point Counter").GetComponent<PointCounter>().ToString());
        }
    }

    // Start is called before the first frame update.
    void Start() {
        // Destroy the collectable after a certain amount of time.
        Destroy(gameObject, lifeTime);
    }   
}   
