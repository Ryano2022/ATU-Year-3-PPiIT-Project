using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawning : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private float spawnInterval = 2.5f;
    private CollectableSP[] spawnPoints;
    private float spawnTimer = 0.0f;

    // Start is called before the first frame update.
    void Start() {
        // Set up the spawn points.
        spawnPoints = FindObjectsOfType<CollectableSP>();

        if(spawnPoints.Length > 0) {
            Debug.Log("Number of spawn points found: " + spawnPoints.Length);
        }
        else {
            Debug.Log("No spawn points found. ");
            return;
        }

        // Spawn the collectables.
        SpawnCollectable();
    }

    void Update() {
        // Check to make sure the timer hasn't ended before spawning.
        if(!(Timer.levelTime <= 0)) {
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnInterval) {
                SpawnCollectable();
                spawnTimer = 0.0f;
            }   
        }
    }

    private void SpawnCollectable() {
        // Get a random spawn point.
        int randomIndex = Random.Range(0, spawnPoints.Length);
        CollectableSP spawnPoint = spawnPoints[randomIndex];
        Debug.Log("Spawned a collectable at " + spawnPoint.name);

        // Spawn the collectable.
        GameObject collectable = Instantiate(collectablePrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
