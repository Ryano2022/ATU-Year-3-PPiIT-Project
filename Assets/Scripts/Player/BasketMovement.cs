using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float minX = -2f;
    [SerializeField] private float maxX = 2f;
    private Rigidbody2D rb;

    // Start is called before the first frame update.
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    void Update() {
        // Get the acceleration from the device and add force.
        Vector2 acceleration = Input.acceleration;
        acceleration.y = 0f; // Lock the y axis.
        rb.AddForce(acceleration * moveSpeed);

        // Clamp the position within the boundaries
        Vector2 stayInBounds = transform.position;
        stayInBounds.x = Mathf.Clamp(stayInBounds.x, minX, maxX); // Clamp the x position.
        transform.position = stayInBounds;
    }
}
