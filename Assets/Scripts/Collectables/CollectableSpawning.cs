using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawning : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab;
    [SerializeField] private int amountToSpawn = 5;
    [SerializeField] private float spawnInterval = 1.0f;
    private CollectableSP[] spawnPoints;

    // Start is called before the first frame update.
    void Start() {
        // Set up the spawn points.
        spawnPoints = FindObjectsOfType<CollectableSP>();

        if(spawnPoints.Length > 0) {
            Debug.Log("Spawn points found: " + spawnPoints.Length);
        }
        else {
            Debug.Log("No spawn points found. ");
            return;
        }

        // Spawn the collectables.
        SpawnCollectables();
    }

    // Update is called once per frame.
    void Update()
    {
        // Check if it's time to spawn a new collectable.
        if (Time.time >= spawnInterval)
        {
            // Spawn the collectables.
            SpawnCollectables();

            // Reset the spawn interval.
            spawnInterval = Time.time + spawnInterval;
        }
    }


    // Spawn the collectables.
    private void SpawnCollectables() {
        for(int i = 0; i < amountToSpawn; i++) {
            // Get a random spawn point.
            int randomIndex = Random.Range(0, spawnPoints.Length);
            CollectableSP spawnPoint = spawnPoints[randomIndex];
            Debug.Log("Spawn point: " + spawnPoint.name);

            // Spawn the collectable.
            GameObject collectable = Instantiate(collectablePrefab, spawnPoint.transform.position, Quaternion.identity);
            Debug.Log("Collectable spawned. ");
        }
    }
}
