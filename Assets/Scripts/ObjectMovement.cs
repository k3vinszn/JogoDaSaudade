using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float moveSpeed = 5f;
    public float spawnInterval = 3f;
    public float minYPosition = -2f; // Minimum Y position
    public float maxYPosition = 2f;  // Maximum Y position

    void Start()
    {
        // Start spawning objects every spawnInterval seconds
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Random Y spawn
        float randomYPosition = Random.Range(minYPosition, maxYPosition);

        // Instantiate the object with the random Y position
        Vector3 spawnPosition = new Vector3(transform.position.x, randomYPosition, 0f);
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // Get the object's rigidbody component to control its movement
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

        // Ensure the object doesn't rotate
        rb.freezeRotation = true;

        // Set the object's initial velocity to move left
        rb.velocity = new Vector2(-moveSpeed, 0f);
    }
}

