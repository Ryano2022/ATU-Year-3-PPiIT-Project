using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] public int points = 0; // Points awarded to the player. Starts with 0.
    [SerializeField] private float lifeTime = 5.0f; // Time before the collectable disappears.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checking for any collision at all just for testing purposes.
        //Debug.Log("Collision detected with " + collision.gameObject.name);

        // Check for the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Award the player with a point.
            points++;
            Debug.Log("+1 Point awarded to the player.\nTotal: " + points);
            // Destroy the collectable.
            Destroy(gameObject);

            // Trying to find the point counter for testing purposes.
            //Debug.Log(GameObject.Find("Point Counter").GetComponent<PointCounter>().ToString());

            // Update the point counter.
            GameObject.Find("Point Counter").GetComponent<PointCounter>().UpdatePoints(points);
        }
    }

    // Start is called before the first frame update.
    void Start() {
        // Destroy the collectable after a certain amount of time.
        Destroy(gameObject, lifeTime);
    }   
}   
